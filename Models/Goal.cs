﻿using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Goal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Pass> Passes { get; set; } = new List<Pass>();
}
