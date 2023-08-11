using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Frontend_MVC.Models.ViewModels
{
    public class VentasViewModel
    {
        [Display(Name = "Numero de Orden")]
        public int NumeroOrden { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Cantidad Vendida")]
        public int CantidadVendida { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Plato Vendido")]
        public int PlatoId { get; set; }

        public string Plato { get; set; } = null!;
    }
}

