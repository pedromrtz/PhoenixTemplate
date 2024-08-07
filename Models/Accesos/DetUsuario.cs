using System;
using System.Collections.Generic;

namespace PhoenixTemplate.Models.Accesos;

public partial class DetUsuario
{
    public int IdDetUser { get; set; }

    public int IdUser { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int IdGenero { get; set; }

    public int IdTipoDoc { get; set; }

    public string Documento { get; set; } = null!;

    public string? Celular { get; set; }

    public int IdPerfil { get; set; }

    public virtual CatGenero IdGeneroNavigation { get; set; } = null!;

    public virtual CatPerfile IdPerfilNavigation { get; set; } = null!;

    public virtual CatTipoDocumento IdTipoDocNavigation { get; set; } = null!;

    public virtual Usuario IdUserNavigation { get; set; } = null!;
}
