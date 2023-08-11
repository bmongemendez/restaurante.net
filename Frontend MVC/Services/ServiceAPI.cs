using Newtonsoft.Json;
using System.Text;
using Frontend_MVC.Models;
using Frontend_MVC.Models.ViewModels;
using System.Security.Cryptography;
using Humanizer;

namespace Frontend_MVC.Services
{
    public class ServiceAPI : IService
    {

        private readonly string _baseurl;
        private readonly HttpClient cliente = new();

        public ServiceAPI()
        {

            _baseurl = "https://localhost:7077/";
            cliente.BaseAddress = new Uri(_baseurl);
        }

        public async Task<bool> DeleteClientes(int id)
        {
            bool respuesta = false;

            var response = await cliente.DeleteAsync($"api/Clientes/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> DeletePlatos(int id)
        {
            bool respuesta = false;

            var response = await cliente.DeleteAsync($"api/Platos/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> DeleteReservas(int id)
        {
            bool respuesta = false;

            var response = await cliente.DeleteAsync($"api/Reservas/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> DeleteVentas(int id)
        {
            bool respuesta = false;

            var response = await cliente.DeleteAsync($"api/Ventas/{id}");

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<List<CategoriasModel>> GetCategorias()
        {
            List<CategoriasModel> categorias = new();
            
            
            var response = await cliente.GetAsync($"api/Categorias");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<CategoriasModel>>(json_respuesta);

                if (resultado != null)
                {
                    categorias = resultado;
                }
            }
            return categorias;
        }

        public async Task<PlatosModel> GetPlatoPorID(int id)
        {
            PlatosModel lista = new();
            
            
            var response = await cliente.GetAsync($"api/Platos/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<PlatosModel>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<List<PlatosModel>> GetPlatos()
        {
            List<PlatosModel> lista = new();
            
            var response = await cliente.GetAsync("api/Platos");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<PlatosModel>>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<ReservasViewModel> GetReservaPorID(int id)
        {
            ReservasViewModel lista = new();


            var response = await cliente.GetAsync($"api/Reservas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<ReservasViewModel>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<List<ReservasViewModel>> GetReservas()
        {
            List<ReservasViewModel> lista = new();


            var response = await cliente.GetAsync("api/Reservas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<ReservasViewModel>>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<VentasModel> GetVentaPorID(int id)
        {
            VentasModel lista = new();
            
            
            var response = await cliente.GetAsync($"api/Ventas/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<VentasModel>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<List<VentasModel>> GetVentas()
        {
            List<VentasModel> lista = new();
            
            
            var response = await cliente.GetAsync("api/Ventas");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<VentasModel>>(json_respuesta);

                if (resultado != null)
                {
                    lista = resultado;
                }
            }
            return lista;
        }

        public async Task<List<ReportesVentasViewModel>> ObtenerVentasDia(DateTime dia = default)
        {
            if (dia == default)
            {
                dia = DateTime.Today; // Usa la fecha actual sin la hora
            }

            List<ReportesVentasViewModel>? lista = new();

            var response = await cliente.GetAsync($"api/Reportes/ventas-dia/{Uri.EscapeDataString(dia.Date.ToString("yyyy-MM-dd"))}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<VentasModel>>(json_respuesta);

                if (resultado != null)
                {
                    foreach (VentasModel venta in resultado)
                    {
                        ReportesVentasViewModel reporteVenta = new()
                        {
                            CantidadVendida = venta.CantidadVendida,
                            NumeroOrden = venta.NumeroOrden,
                            Plato = venta.Plato?.Nombre,
                            FechaHora = venta.FechaHora,
                            Imagen = venta.Plato?.Imagen
                        };
                        lista.Add(reporteVenta);
                    }
                }
                else {
                    lista = null;
                }
            }
            return lista;
        }

        public async Task<List<ReportesVentasViewModel>> ObtenerVentasMes(DateTime mes = default)
        {
            if (mes == default)
            {
                mes = DateTime.Today; // Usa la fecha actual sin la hora
            }

            List<ReportesVentasViewModel>? lista = new();

            var response = await cliente.GetAsync($"api/Reportes/ventas-mes/{Uri.EscapeDataString(mes.Date.ToString("yyyy-MM-dd"))}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<VentasModel>>(json_respuesta);

                if (resultado != null)
                {
                    foreach (VentasModel venta in resultado)
                    {
                        ReportesVentasViewModel reporteVenta = new()
                        {
                            CantidadVendida = venta.CantidadVendida,
                            NumeroOrden = venta.NumeroOrden,
                            Plato = venta.Plato?.Nombre,
                            FechaHora = venta.FechaHora,
                            Imagen = venta.Plato?.Imagen
                        };
                        lista.Add(reporteVenta);
                    }
                }
                else
                {
                    lista = null;
                }
            }
            return lista;
        }

        public async Task<List<ReportesVentasViewModel>> ObtenerVentasRango(DateTime inicio = default, DateTime fin = default)
        {
            if (inicio == default)
            {
                inicio = DateTime.Today; // Usa la fecha actual sin la hora
            }

            if (fin == default)
            {
                fin = DateTime.Today; // Usa la fecha actual sin la hora
            }

            List<ReportesVentasViewModel>? lista = new();

            var response = await cliente.GetAsync($"api/Reportes/ventas-rango/{Uri.EscapeDataString(inicio.Date.ToString("yyyy-MM-dd"))}/{Uri.EscapeDataString(fin.Date.ToString("yyyy-MM-dd"))}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<List<VentasModel>>(json_respuesta);

                if (resultado != null)
                {
                    foreach (VentasModel venta in resultado)
                    {
                        ReportesVentasViewModel reporteVenta = new()
                        {
                            CantidadVendida = venta.CantidadVendida,
                            NumeroOrden = venta.NumeroOrden,
                            Plato = venta.Plato?.Nombre,
                            FechaHora = venta.FechaHora,
                            Imagen = venta.Plato?.Imagen
                        };
                        lista.Add(reporteVenta);
                    }
                }
                else
                {
                    lista = null;
                }
            }
            return lista;
        }

        public async Task<PlatosViewModel> ObtenerPlatoMasVendidoDelMes(DateTime mes = default)
        {
            if (mes == default)
            {
                mes = DateTime.Today; // Usa la fecha actual sin la hora
            }

            PlatosViewModel? plato = null;

            var response = await cliente.GetAsync($"api/Reportes/plato-mas-vendido-mes/{Uri.EscapeDataString(mes.Date.ToString("yyyy-MM-dd"))}");

            if (response.IsSuccessStatusCode)
            {
                var json_respuesta = await response.Content.ReadAsStringAsync();

                var resultado = JsonConvert.DeserializeObject<PlatosViewModel>(json_respuesta);

                if (resultado != null)
                {
                    plato = resultado;
                }
            }
            return plato;
        }

        public async Task<bool> PostPlatos(PlatosModel obj_plato)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_plato), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/Platos", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> PostReservas(ReservasModel obj_plato)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_plato), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/Reservas", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> PostVentas(VentasModel obj_Venta)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_Venta), Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync($"api/Ventas", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
        public async Task<bool> PutPlatos(PlatosModel obj_plato)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_plato), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Platos/{obj_plato.Id}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> PutReservas(ReservasModel obj_reserva)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_reserva), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Reservas/{obj_reserva.NumeroReserva}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }

        public async Task<bool> PutVentas(VentasModel obj_Venta)
        {
            bool respuesta = false;

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_Venta), Encoding.UTF8, "application/json");

            var response = await cliente.PutAsync($"api/Ventas/{obj_Venta.NumeroOrden}", contenido);

            if (response.IsSuccessStatusCode)
            {
                respuesta = true;
            }
            return respuesta;
        }
    }
}
