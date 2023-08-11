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
    public class PlatosController : ControllerBase
    {

        private readonly ProyectoDbContext _context;

        public PlatosController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/<PlatosController>
        [HttpGet]
        public ActionResult<IEnumerable<PlatosModel>> Get()
        {
            List<PlatosModel> lista = _context.Platos.Include(plato => plato.Categoria).ToList();
            return Ok(lista);
        }

        // GET api/<PlatosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var plato = await _context.Platos.Include(plato => plato.Categoria).FirstOrDefaultAsync(plato => plato.Id == id);
            if (plato != null)
            {
                _context.SaveChanges();
                return Ok(plato);
            }
            return NotFound();
        }

        // POST api/<PlatosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlatosModel platoInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plato = new PlatosModel
            {
                Nombre = platoInput.Nombre,
                Descripcion = platoInput.Descripcion,
                Precio = platoInput.Precio,
                CategoriaId = platoInput.CategoriaId,
                Imagen = platoInput.Imagen
            };

            _context.Platos.Add(plato);

            // Buscamos la categoria de la base de datos y la agregamos como referencia
            var categoria = await _context.Categorias.FindAsync(platoInput.CategoriaId);
            plato.Categoria = categoria;

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = plato.Id }, plato);
        }

        // PUT api/<PlatosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlatosModel value)
        {
            var plato = await _context.Platos.FindAsync(id);
            if (plato != null) {
                plato.Id = value.Id;
                plato.Nombre = value.Nombre;
                plato.Descripcion = value.Descripcion;
                plato.Imagen = value.Imagen;
                plato.Precio = value.Precio;
                plato.CategoriaId = value.Precio;
                plato.Categoria = value.Categoria;
                var categoria = await _context.Categorias.FindAsync(value.CategoriaId);
                plato.Categoria = categoria;
                _context.SaveChanges();
                return Ok(plato);
            }
            return NotFound();
        }

        // DELETE api/<PlatosController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var plato = _context.Platos.Find(id);
            if (plato != null) {
                _context.Remove(plato);
                _context.SaveChanges();
                return Ok(id);
            }
            return NotFound();
            
        }
    }
}
