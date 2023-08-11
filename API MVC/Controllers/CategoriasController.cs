using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_MVC.Data;
using API_MVC.Models;

namespace API_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : Controller
    {

        private readonly ProyectoDbContext _context;

        public CategoriasController(ProyectoDbContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public ActionResult<IEnumerable<CategoriasModel>> Get()
        {
            List<CategoriasModel> lista = _context.Categorias.ToList();
            return Ok(lista);
        }
    }
}