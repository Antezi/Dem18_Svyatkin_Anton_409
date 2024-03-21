using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Request
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string? Organisation { get; set; }

    public string Note { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string Passport { get; set; } = null!;

    public int Passid { get; set; }

    public string? Photo { get; set; }

    public int? Purpose { get; set; }

    public virtual Purpose? PurposeNavigation { get; set; }

    public virtual User User { get; set; } = null!;
}
