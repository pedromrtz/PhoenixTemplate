using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string UserName { get; set; } = null!;

    public string? Clave { get; set; }

    public string? Correo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string? Token { get; set; }

    public DateTime? FechaToken { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetUsuario> DetUsuarios { get; set; } = new List<DetUsuario>();

    public virtual ICollection<PermisosVistaUser> PermisosVistaUsers { get; set; } = new List<PermisosVistaUser>();
}
