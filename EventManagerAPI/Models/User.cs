using System;
using EventManagerAPI.Models.Enums;

namespace EventManagerAPI.Models;

public class User
{
    public Guid Id { get; set; }

    public string Email { get; set; }  = string.Empty;

    public string PasswordHash { get; set; }  = string.Empty;

    public ERole Role{ get; set; }

    public DateTime CreatedAt { get; set; }

}
