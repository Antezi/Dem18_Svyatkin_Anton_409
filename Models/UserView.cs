using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class UserView
{
    public int Id { get; set; }

    public int RoleCode { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Patronymic { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Passport { get; set; }

    public string? Appointment { get; set; }

    public DateOnly Birthdate { get; set; }

    public string? Photo { get; set; }

    public string? Passportscan { get; set; }
    public string? FullPhotoPath { get; set; }
    public string? FullPassportscanPath { get; set; }
    public string FIO { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}