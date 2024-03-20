using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Userrole
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual User? User { get; set; }
}
