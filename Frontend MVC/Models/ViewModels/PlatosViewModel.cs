using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Frontend_MVC.Models.ViewModels
{
    public class PlatosViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido**")]
        public string Descripcion { get; set; } = null!;

        public byte[]? Imagen { get; set; }

        [NotMapped]
        [DisplayName("Subir Imagen")]
        [Required(ErrorMessage = "Este campo es requerido**")]
        public IFormFile? ImagenSubida { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }

        [Display(Name="Categoría")]
        public string? CategoriaNombre { get; set; }

    }

}
