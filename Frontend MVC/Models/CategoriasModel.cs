using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Frontend_MVC.Models;

public partial class CategoriasModel
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<PlatosModel>? Platos { get; set; } = new List<PlatosModel>();
}
