using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class CatGenero
{
    public int IdGenero { get; set; }

    public string? Genero { get; set; }

    public int Estado { get; set; }

    public virtual ICollection<DetUsuario> DetUsuarios { get; set; } = new List<DetUsuario>();
}
