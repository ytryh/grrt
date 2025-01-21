using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Absence
{
    public int Id { get; set; }

    public DateOnly Date { get; set; }

    public int IdReason { get; set; }

    public int IdSotrudnik { get; set; }

    public int IdSotZameni { get; set; }

    public virtual Reason IdReasonNavigation { get; set; } = null!;

    public virtual Sotrudniki IdSotrudnikNavigation { get; set; } = null!;
}
