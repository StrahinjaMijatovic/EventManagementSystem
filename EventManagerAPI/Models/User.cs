using System;
using EventManagerAPI.Models.Enums;

namespace EventManagerAPI.Models;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string PasswordHash { get; set; }

    public Role Role{ get; set; }

    public DateTime CreatedAt { get; set; }

}
