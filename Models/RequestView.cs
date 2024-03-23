using System;
using System.Collections.Generic;
using Avalonia.Data;
using Avalonia.Media.Imaging;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class RequestView
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
    public string Passportscan { get; set; } = null!;
    public string FirstnameView { get; set; }
    public string LastnameView { get; set; }
    public string PatronymicView { get; set; }
    public Bitmap PhotoView { get; set; }
    public string EmailView { get; set; }
    public string PhoneView { get; set; }
    public string PassportView { get; set; }
    public string OrganisationView { get; set; }
    public string NoteView { get; set; }
    public string BirthdateView { get; set; }
    public string StartDateView { get; set; }
    public string EndDateView { get; set; }
    public string TypeView { get; set; }
    public string PassportscanView { get; set; }

    public int Passid { get; set; }

    public string? Photo { get; set; }

    public int? Divisionrequestid { get; set; }

    public int? Typeid { get; set; }

    public virtual Divisionrequest? Divisionrequest { get; set; }

    public virtual Pass Pass { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}