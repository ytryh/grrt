using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdEventType { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly Date { get; set; }

    public virtual EventType IdEventTypeNavigation { get; set; } = null!;
}
