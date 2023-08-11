using System.ComponentModel.DataAnnotations;
using System;

namespace Frontend_MVC.Models.ViewModels
{
	public class ReservasViewModel
	{
        [Display(Name = "Número de Reserva")]
        public int NumeroReserva { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Fecha y Hora")]
        public DateTime FechaHora { get; set; }

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Nombre Cliente")]
        public string NombreCiente { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es requerido**")]
        [Display(Name = "Numero de Personas")]
        public int NumeroPersonas { get; set; }
    }
}

