using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_MVC.Data;
using API_MVC.Models;

namespace API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {

        private readonly ProyectoDbContext _context;

        public ReservasController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/<ReservasController>
        [HttpGet]
        public ActionResult<IEnumerable<ReservasModel>> Get()
        {
            List<ReservasModel> lista = _context.Reservas.ToList();
            return Ok(lista);
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                _context.SaveChanges();
                return Ok(reserva);
            }
            return NotFound();
        }

        // POST api/<ReservasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReservasModel reservaInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reserva = new ReservasModel
            {
                FechaHora = reservaInput.FechaHora,
                NumeroPersonas = reservaInput.NumeroPersonas,
                NombreCiente = reservaInput.NombreCiente
            };

            _context.Reservas.Add(reserva);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = reserva.NumeroReserva }, reserva);
        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReservasModel reservaInput)
        {
            var reserva = await _context.Reservas.FindAsync(id);
            if (reserva != null)
            {
                reserva.FechaHora = reservaInput.FechaHora;
                reserva.NumeroPersonas = reservaInput.NumeroPersonas;
                reserva.NombreCiente = reservaInput.NombreCiente;
                _context.SaveChanges();
                return Ok(reserva);
            }
            return NotFound();
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                _context.Remove(reserva);
                _context.SaveChanges();
                return Ok(id);
            }
            return NotFound();

        }
    }
}