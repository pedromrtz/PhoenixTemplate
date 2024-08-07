using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class CatTipoDocumento
{
    public int IdTipoDoc { get; set; }

    public string? TipoDoc { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetUsuario> DetUsuarios { get; set; } = new List<DetUsuario>();
}
