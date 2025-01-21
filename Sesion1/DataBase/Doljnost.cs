using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Doljnost
{
    public int Id { get; set; }

    public string NameDoljnost { get; set; } = null!;

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}
