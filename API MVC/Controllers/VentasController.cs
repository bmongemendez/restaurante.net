using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using API_MVC.Data;
using API_MVC.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private readonly ProyectoDbContext _context;

        public VentasController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/<VentasController>
        [HttpGet]
        public ActionResult<IEnumerable<VentasModel>> Get()
        {
            List<VentasModel> lista = _context.Ventas.Include(venta => venta.Plato).ToList();
            return Ok(lista);
        }

        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var venta = await _context.Ventas.Include(venta => venta.Plato).FirstOrDefaultAsync(v => v.NumeroOrden == id);
            if (venta != null)
            {
                _context.SaveChanges();
                return Ok(venta);
            }
            return NotFound();
        }

        // POST api/<VentasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VentasModel ventaInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var venta = new VentasModel
            {
                FechaHora = ventaInput.FechaHora,
                CantidadVendida = ventaInput.CantidadVendida,
                PlatoId = ventaInput.PlatoId,
                
            };

            // Aquí podrías cargar la categoría desde la base de datos y asignarla al venta
            var plato = await _context.Platos.FindAsync(ventaInput.PlatoId);
            venta.Plato = plato;

            _context.Ventas.Add(venta);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = venta.NumeroOrden }, venta);
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VentasModel ventaInput)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                venta.FechaHora = ventaInput.FechaHora;
                venta.CantidadVendida = ventaInput.CantidadVendida;
                venta.PlatoId = ventaInput.PlatoId;
                var plato = await _context.Platos.FindAsync(ventaInput.NumeroOrden);
                venta.Plato = plato;
                _context.SaveChanges();
                return Ok(venta);
            }
            return NotFound();
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta != null)
            {
                _context.Remove(venta);
                _context.SaveChanges();
                return Ok(id);
            }
            return NotFound();

        }
    }
}
