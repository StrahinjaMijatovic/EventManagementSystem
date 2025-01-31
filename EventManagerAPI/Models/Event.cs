using System;

namespace EventManagerAPI.Models;

public class Event
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public DateTime Date { get; set; }

    public int MaxParticipants { get; set; }

    public Guid OrganizerId { get; set; } 

}
