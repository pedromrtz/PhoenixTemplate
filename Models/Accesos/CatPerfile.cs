using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class CatPerfile
{
    public int IdPerfil { get; set; }

    public string? Perfil { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetUsuario> DetUsuarios { get; set; } = new List<DetUsuario>();
}
