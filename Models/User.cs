using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class User
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

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
