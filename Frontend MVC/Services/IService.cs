using Frontend_MVC.Models;
using Frontend_MVC.Models.ViewModels;

namespace Frontend_MVC.Services
{
    public interface IService
    {
        //Ventas
        public Task<List<VentasModel>> GetVentas();
        public Task<VentasModel> GetVentaPorID(int id);
        public Task<bool> PostVentas(VentasModel obj_plato);
        public Task<bool> PutVentas(VentasModel obj_plato);
        public Task<bool> DeleteVentas(int id);

        //Platos
        public Task<List<PlatosModel>> GetPlatos();
        public Task<PlatosModel> GetPlatoPorID(int id);
        public Task<bool> PostPlatos(PlatosModel obj_plato);
        public Task<bool> PutPlatos(PlatosModel obj_plato);
        public Task<bool> DeletePlatos(int id);

        //Reportes
        public Task<List<ReportesVentasViewModel>> ObtenerVentasMes(DateTime mes = default);
        public Task<List<ReportesVentasViewModel>> ObtenerVentasDia(DateTime dia = default);
        public Task<List<ReportesVentasViewModel>> ObtenerVentasRango(DateTime inicio = default, DateTime Fin = default);
        public Task<PlatosViewModel> ObtenerPlatoMasVendidoDelMes(DateTime mes = default);

        //Categorias
        public Task<List<CategoriasModel>> GetCategorias();

        //Reservas
        public Task<List<ReservasViewModel>> GetReservas();
        public Task<ReservasViewModel> GetReservaPorID(int id);
        public Task<bool> PostReservas(ReservasModel obj_plato);
        public Task<bool> PutReservas(ReservasModel obj_plato);
        public Task<bool> DeleteReservas(int id);
    }
}
