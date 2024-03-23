using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Divisionrequest
{
    public int Id { get; set; }

    public int Divisionid { get; set; }

    public string Fio { get; set; } = null!;

    public virtual Division Division { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
