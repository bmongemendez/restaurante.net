using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Frontend_MVC.Services;

namespace Frontend_MVC.Controllers
{
    public class ReportesController : Controller
    {
        private readonly IService _iservice;


        public ReportesController(IService iservice)
        {
            _iservice = iservice;
        }

        // GET: Reportes
        public async Task<IActionResult> IndexVentasDia()
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasDia();
            return View("VentasDelDia");
        }

        // GET: Reportes/VentasDelDia/{fecha}
        public async Task<IActionResult> VentasDia(DateTime FechaDia)
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasDia(FechaDia);
            return View("VentasDelDia");
        }

        // GET: Reportes
        public async Task<IActionResult> IndexVentasMes()
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasMes();
            return View("VentasDelMes");
        }

        // GET: Reportes/VentasDelDia/{fecha}
        public async Task<IActionResult> VentasMes(DateTime FechaMes)
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasMes(FechaMes);
            return View("VentasDelMes");
        }

        // GET: Reportes
        public async Task<IActionResult> IndexVentasRango()
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasRango();
            return View("VentasEnUnRango");
        }

        // GET: Reportes/VentasDelDia/{fecha}
        public async Task<IActionResult> VentasRango(DateTime FechaInicio, DateTime FechaFin)
        {
            ViewBag.Ventas = await _iservice.ObtenerVentasRango(FechaInicio, FechaFin);
            return View("VentasEnUnRango");

        }

        // GET: Reportes
        public async Task<IActionResult> IndexPlatoMasVendidoDelMes()
        {
            ViewBag.Plato = await _iservice.ObtenerPlatoMasVendidoDelMes();
            return View("PlatoMasVendidoMes");
        }

        // GET: Reportes
        public async Task<IActionResult> PlatoMasVendidoDelMes(DateTime FechaMes)
        {
            ViewBag.Plato = await _iservice.ObtenerPlatoMasVendidoDelMes(FechaMes);
            return View("PlatoMasVendidoMes");
        }

    }
}