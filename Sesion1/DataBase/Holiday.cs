using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Holiday
{
    public int Id { get; set; }

    public DateOnly DateOfStart { get; set; }

    public DateOnly DateofEnd { get; set; }

    public int IdSotrudnik { get; set; }
}
