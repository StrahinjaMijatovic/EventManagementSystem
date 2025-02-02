using System;
using Marten;
using Microsoft.AspNetCore.Mvc;
using EventManagerAPI.Models;
using EventManagerAPI.Models.Enums;

namespace EventManagerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegistrationsController: ControllerBase
{
    private readonly IDocumentSession _session;

    public RegistrationsController(IDocumentSession session)
    {
        _session = session;
    }

    //Dobavljanje svih prijava
    [HttpGet]
    public async Task<IActionResult> GetRegistrations()
    {
        var registrations = await _session.Query<Registration>().ToListAsync();
        return Ok(registrations);
    }

    //Dodaj novu prijavu
    [HttpPost]
    public async Task<IActionResult> AddRegistration([FromBody]Registration registration)
    {
        _session.Store(registration);
        await _session.SaveChangesAsync();
        return Ok(registration);
    }

    //Azuriras status prijave
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateRegistration(Guid id, [FromBody] EStatus status)
    {
        var registration = await _session.LoadAsync<Registration>(id);
        if (registration == null)
            return NotFound();
        
        registration.Status = status;
        _session.Store(registration);
        await _session.SaveChangesAsync();
        return Ok(registration);
    }

}
