using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Reason
{
    public int Id { get; set; }

    public string Missing { get; set; } = null!;

    public string Otgyl { get; set; } = null!;

    public string? Komand { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();
}
