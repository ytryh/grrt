using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Coment
{
    public int Id { get; set; }

    public int DocumentId { get; set; }

    public string Text { get; set; } = null!;

    public DateOnly DateCreate { get; set; }

    public DateOnly DateUpdate { get; set; }

    public string? Author { get; set; }

    public virtual Document Document { get; set; } = null!;
}
