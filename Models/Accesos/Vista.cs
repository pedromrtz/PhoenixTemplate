using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class Vista
{
    public int IdVista { get; set; }

    public string Nombre { get; set; } = null!;

    public int Nivel { get; set; }

    public int Padre { get; set; }

    public string Controller { get; set; } = null!;

    public string Vista1 { get; set; } = null!;

    public string? Icon { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<PermisosVistaUser> PermisosVistaUsers { get; set; } = new List<PermisosVistaUser>();
}
