using System;
using JasperFx.Core;
using Marten;
using Microsoft.AspNetCore.Mvc;
using EventManagerAPI.Models;

namespace EventManagerAPI.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IDocumentSession _session;

    public UsersController(IDocumentSession session)
    {
        _session = session;
    }

    //Dobavljanje svih korisnika
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _session.Query<User>().ToListAsync();
        return Ok(users);
    }

    //Dodavanje novog korsinika
    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody]User user)
    {
        _session.Store(user);
        await _session.SaveChangesAsync();
        return Ok(user);
    }

    //Azuriraj korsinika
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] User updateUser)
    {
        var user = await _session.LoadAsync<User>(id);
        if (user == null)
            return NotFound();

        user.Email = updateUser.Email;
        user.PasswordHash = updateUser.PasswordHash;
        user.Role = updateUser.Role;

        _session.Store(user);
        await _session.SaveChangesAsync();
        return Ok(user);
    }

    //Obrisi korsinika
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        _session.Delete<User>(id);
        await _session.SaveChangesAsync();
        return NoContent();
    }

}
