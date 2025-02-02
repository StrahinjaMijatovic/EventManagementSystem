using System;

namespace EventManagerAPI.Models;

public class Event
{
    public Guid Id { get; set; }

    //string is empty onda će user.Name biti prazan string "", što sprečava NullReferenceException.
    public string Name { get; set; }  = string.Empty;

    public string Description { get; set; }  = string.Empty;

    public string Location { get; set; }  = string.Empty;

    public DateTime Date { get; set; }

    public int MaxParticipants { get; set; }

    public Guid OrganizerId { get; set; } 

}
