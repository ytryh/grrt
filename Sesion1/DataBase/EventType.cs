using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class EventType
{
    public string Id { get; set; } = null!;

    public string EventName { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
