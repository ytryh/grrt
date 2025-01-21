using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Calendar
{
    public int Id { get; set; }

    public DateOnly DateofStart { get; set; }

    public DateOnly DateOfEnd { get; set; }

    public int IdSotr { get; set; }
}
