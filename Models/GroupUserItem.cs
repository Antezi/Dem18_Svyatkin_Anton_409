using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class GroupUserItem
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string? Photo { get; set; }

    public string? Passportscan { get; set; }

    public int Id { get; set; }

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
