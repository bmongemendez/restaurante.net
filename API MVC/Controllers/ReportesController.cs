using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using API_MVC.Data;
using API_MVC.Models;

namespace API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {

        private readonly ProyectoDbContext _context;

        public ReportesController(ProyectoDbContext context)
        {
            _context = context;
        }

        [HttpGet("ventas-mes/{fecha}")]
        public async Task<IActionResult> VentasDelMes(string fecha)
        {
            if (!DateTime.TryParse(fecha, out var fechaSeleccionada))
            {
                return BadRequest("Formato de fecha incorrecto.");
            }

            var fechaInicio = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, 1);
            var fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

            var ventas = await _context.Ventas
                .Where(venta => venta.FechaHora >= fechaInicio && venta.FechaHora <= fechaFin)
                .Include(venta => venta.Plato)
                .ToListAsync();

            return ventas.Count != 0 ? Ok(ventas) : Ok();
        }

        [HttpGet("ventas-dia/{fecha}")]
        public async Task<IActionResult> VentasDelDia(string fecha)
        {
            if (!DateTime.TryParse(fecha, out var fechaSeleccionada))
            {
                return BadRequest("Formato de fecha incorrecto.");
            }

            var fechaActual = fechaSeleccionada.Date;

            var ventas = await _context.Ventas
                .Where(venta => venta.FechaHora.Date == fechaActual)
                .Include(venta => venta.Plato)
                .ToListAsync();

            return ventas.Count != 0 ? Ok(ventas) : Ok();
        }

        [HttpGet("ventas-rango/{fechaInicio}/{fechaFin}")]
        public async Task<IActionResult> VentasEnRango(string fechaInicio, string fechaFin)
        {
            if (!DateTime.TryParse(fechaInicio, out var fechaInicioSeleccionada) ||
                !DateTime.TryParse(fechaFin, out var fechaFinSeleccionada))
            {
                return BadRequest("Formato de fecha incorrecto.");
            }

            var ventas = await _context.Ventas
                .Where(venta => venta.FechaHora >= fechaInicioSeleccionada && venta.FechaHora <= fechaFinSeleccionada)
                .Include(venta => venta.Plato)
                .ToListAsync();

            return ventas.Count != 0 ? Ok(ventas) : Ok();
        }

        [HttpGet("plato-mas-vendido-mes/{fecha}")]
        public async Task<IActionResult> PlatoMasVendidoMes(string fecha)
        {
            if (!DateTime.TryParse(fecha, out var fechaSeleccionada))
            {
                return BadRequest("Formato de fecha incorrecto.");
            }

            var fechaInicio = new DateTime(fechaSeleccionada.Year, fechaSeleccionada.Month, 1);
            var fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

            var platoMasVendido = await _context.Ventas
                .Where(venta => venta.FechaHora >= fechaInicio && venta.FechaHora <= fechaFin)
                .GroupBy(venta => venta.Plato)
                .OrderByDescending(grupo => grupo.Sum(venta => venta.CantidadVendida))
                .Select(grupo => grupo.Key)
                .FirstOrDefaultAsync();

            return platoMasVendido != null ? Ok(platoMasVendido) : Ok();
        }
    }
}
