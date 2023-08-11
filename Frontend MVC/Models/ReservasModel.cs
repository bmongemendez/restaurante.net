namespace Frontend_MVC.Models
{
    public partial class ReservasModel
    {
        public int NumeroReserva { get; set; }

        public DateTime FechaHora { get; set; }

        public string NombreCiente { get; set; } = null!;

        public int NumeroPersonas { get; set; }
    }
}
