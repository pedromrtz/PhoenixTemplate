using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class PermisosVistaUser
{
    public int IdPvu { get; set; }

    public int IdUser { get; set; }

    public int IdVista { get; set; }

    public int Estado { get; set; }

    public virtual Usuario IdUserNavigation { get; set; } = null!;

    public virtual Vista IdVistaNavigation { get; set; } = null!;
}
