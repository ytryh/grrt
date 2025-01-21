using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Cabinet
{
    public int Id { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Sotrudniki> Sotrudnikis { get; set; } = new List<Sotrudniki>();
}
