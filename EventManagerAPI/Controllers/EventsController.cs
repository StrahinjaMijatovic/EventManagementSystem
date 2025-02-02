namespace EventManagerAPI.Controllers;

using System;
using Marten;
using Microsoft.AspNetCore.Mvc;
using EventManagerAPI.Models;

[ApiController]
[Route("api/[controller]")]
//Nasledjivanjem ControllerBase klase dobijam funckionalsnoti za rad sa HTTP zahtevima (Ok(), BadRequest()).
public class EventsController : ControllerBase
{
    private readonly IDocumentSession _session;

    public EventsController (IDocumentSession session)
    {
        _session = session;
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        //upit ka bazi _session.Query<Event>() → Pristupa tabeli Event u bazi podataka.
        var events = await _session.Query<Event>().ToListAsync();
        return Ok(events);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
    {
        _session.Store(newEvent);
        await _session.SaveChangesAsync();
        return Ok(newEvent);

    }
}
