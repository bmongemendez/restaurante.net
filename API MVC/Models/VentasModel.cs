using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace API_MVC.Models;

public partial class VentasModel
{
    public int NumeroOrden { get; set; }

    public DateTime FechaHora { get; set; }

    public int CantidadVendida { get; set; }

    public int PlatoId { get; set; }

    public virtual PlatosModel? Plato { get; set; } = null!;
}
