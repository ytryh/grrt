using System;
using System.Collections.Generic;

namespace Sesion1.DataBase;

public partial class Sotrudniki
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int IdDepartament { get; set; }

    public int IdOtdel { get; set; }

    public int IdDoljnost { get; set; }

    public string RabPhone { get; set; } = null!;

    public int? PhoneNumber { get; set; }

    public int IdCabinet { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly DateofBirday { get; set; }

    public string? Assistant { get; set; }

    public string? Other { get; set; }

    public virtual ICollection<Absence> Absences { get; set; } = new List<Absence>();

    public virtual Cabinet IdCabinetNavigation { get; set; } = null!;

    public virtual Departament IdDepartamentNavigation { get; set; } = null!;

    public virtual Doljnost IdDoljnostNavigation { get; set; } = null!;

    public virtual Otdel IdOtdelNavigation { get; set; } = null!;
}
