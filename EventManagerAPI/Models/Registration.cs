using System;
using EventManagerAPI.Models.Enums;

namespace EventManagerAPI.Models;

public class Registration
{
    public Guid Id { get; set; }

    public Guid EventId { get; set; }

    public Guid ParticpantId { get; set; }

    public Status Status { get; set; }
}
