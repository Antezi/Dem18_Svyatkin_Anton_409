using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int? Divisionid { get; set; }

    public int? Departmentid { get; set; }

    public string? Code { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Division? Division { get; set; }
}
