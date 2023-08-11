using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_MVC.Models;

public partial class PlatosModel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public byte[]? Imagen { get; set; }

    public int Precio { get; set; }

    public int CategoriaId { get; set; }

    public virtual CategoriasModel? Categoria { get; set; } = null!;

    public virtual ICollection<VentasModel>? Venta { get; set; } = new List<VentasModel>();
}
