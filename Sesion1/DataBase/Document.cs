using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Document
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime DateCreate { get; set; }

    public DateTime DateUpdate { get; set; }

    public string Category { get; set; } = null!;

    public string? HasComment { get; set; }

    public virtual ICollection<Coment> Coments { get; set; } = new List<Coment>();
}
