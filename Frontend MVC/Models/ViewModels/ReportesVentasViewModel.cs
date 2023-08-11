using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Frontend_MVC.Models.ViewModels
{
    public class ReportesVentasViewModel
    {
        [Display(Name = "Numero de Orden")]
        public int? NumeroOrden { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Día")]
        public DateTime? FechaDia{ get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Mes")]
        public DateTime? FechaMes { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Fecha Inicio")]
        public DateTime? FechaInicio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Fecha Fin")]
        public DateTime? FechaFin { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Fecha y Hora")]
        public DateTime? FechaHora { get; set; }

        [Display(Name = "Cantidad Vendida")]
        public int? CantidadVendida { get; set; }

        [Display(Name = "Plato Vendido")]
        public int? PlatoId { get; set; }

        public string? Plato { get; set; } = null!;

        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Descripcion { get; set; } = null!;

        public byte[]? Imagen { get; set; }

        public int Precio { get; set; }
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [Display(Name = "Categoría")]
        public string? CategoriaNombre { get; set; }
    }
}

