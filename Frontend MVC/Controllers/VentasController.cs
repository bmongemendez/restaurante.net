using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Frontend_MVC.Models;
using Frontend_MVC.Models.ViewModels;
using Frontend_MVC.Services;

namespace Frontend_MVC.Controllers
{
    public class VentasController : Controller
    {
        //private readonly IMemoryCache _cache;
        private readonly IService _iservice;


        public VentasController(/*IMemoryCache cache*/IService iservice)
        {
            //_cache = cache;
            _iservice = iservice;
        }

        // GET: VentasController
        public async Task<ActionResult> Index()
        {
            List<VentasModel> ventas = await _iservice.GetVentas();

            List<VentasViewModel> ventasView = MapearViewVenta(ventas);

            return View(ventasView);
        }

        // GET: VentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VentasController/Create
        public async Task<IActionResult> Create()
        {
            List<PlatosModel> platos = await _iservice.GetPlatos();
            ViewBag.Platos = platos;
            return View();
        }

        // POST: VentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VentasModel Venta)
        {
            try
            {
                await _iservice.PostVentas(Venta);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: VentasController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var venta = await _iservice.GetVentaPorID(id);

            List<VentasViewModel> ventasView = MapearViewVenta(new List<VentasModel> { venta });

            return View(ventasView.First());
        }

        // POST: VentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VentasModel Venta)
        {
            try
            {
                await _iservice.PutVentas(Venta);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VentasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var venta = await _iservice.GetVentaPorID(id);
           
            List<VentasViewModel> ventasView = MapearViewVenta(new List<VentasModel> { venta });

            return View(ventasView.First());
        }

        // POST: VentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _iservice.DeleteVentas(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<VentasViewModel> MapearViewVenta(List<VentasModel> ventas) {

            List<VentasViewModel> ventasAuxiliar = new List<VentasViewModel>();

            foreach(VentasModel venta in ventas) {
                ventasAuxiliar.Add(new VentasViewModel
                {
                    NumeroOrden = venta.NumeroOrden,
                    CantidadVendida = venta.CantidadVendida,
                    FechaHora = venta.FechaHora,
                    Plato = venta.Plato.Nombre
                });
            };
            return ventasAuxiliar;
        }
    }

}
