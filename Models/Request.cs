using System;
using System.Collections.Generic;

namespace Dem18_Svyatkin_Anton_409.Models;

public partial class Request
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public string? Organisation { get; set; }

    public string Note { get; set; } = null!;

    public int Passid { get; set; }

    public int? Divisionrequestid { get; set; }

    public int? Typeid { get; set; }

    public int? Groupusers { get; set; }

    public virtual Divisionrequest? Divisionrequest { get; set; }

    public virtual Groupuser? GroupusersNavigation { get; set; }

    public virtual Pass Pass { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
