using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Pass
{
    public int Id { get; set; }

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public int Goalid { get; set; }

    public virtual Goal Goal { get; set; } = null!;
}
