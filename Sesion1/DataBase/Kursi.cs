using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Kursi
{
    public int Id { get; set; }

    public DateOnly DateofStart { get; set; }

    public DateOnly DateOfEnd { get; set; }

    public string NameClass { get; set; } = null!;

    public int IdSotrudnik { get; set; }

    public string TypeOfTraining { get; set; } = null!;
}
