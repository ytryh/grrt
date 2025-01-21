using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Vacation
{
    public int Id { get; set; }

    public DateOnly DateOfStart { get; set; }

    public DateOnly DateOfEnd { get; set; }

    public int IdSotrunik { get; set; }
}
