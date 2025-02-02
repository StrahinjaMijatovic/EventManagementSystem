using System;
using System.Diagnostics.Tracing;
using EventManagerAPI.Models;


namespace EventManagerAPI.Handlers;

//Sadrži event handler-e za Wolverine i druge event-driven operacije
public static class EventHandlers
{
    public static void HandleEventCreated(EventSourceCreatedEventArgs created)
    {
        //Logika za slanje obavestenja organizatorima
    }

    public static void HandleRegistrationCreated(RegistrationCreated created)
    {
        Console.WriteLine($"Obavestenje: Korisnik {created.ParticipantId} se prijavio na dogadjaj {created.EventId}");
    }

}

public record EventCreated(Event Event);
public record RegistrationCreated(Guid EventId, Guid ParticipantId);