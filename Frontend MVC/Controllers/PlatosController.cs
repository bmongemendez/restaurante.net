using System;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Frontend_MVC.Models;
using Frontend_MVC.Models.ViewModels;
using Frontend_MVC.Services;

namespace Frontend_MVC.Controllers
{
    public class PlatosController : Controller
    {
        private readonly IService _iservice;


        public PlatosController(IService iservice)
        {
            _iservice = iservice;
        }

        // GET: PlatosController
        public async Task<ActionResult> Index()
        {
            List<PlatosModel> platos = await _iservice.GetPlatos();

            List<PlatosViewModel> platosView = mapearViewPlato(platos);

            return View(platosView);
        }

        // GET: PlatosController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = await GetCategorias();
            return View();
        }

        // POST: PlatosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PlatosViewModel plato)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    PlatosModel platoNuevo = new PlatosModel();

                    if (plato.ImagenSubida != null)
                    {
                        using (var ms = new MemoryStream())
                        {
                            plato.ImagenSubida.CopyTo(ms);
                            platoNuevo.Imagen = ms.ToArray();
                        }
                    }
                    
                    platoNuevo.Nombre = plato.Nombre;
                    platoNuevo.CategoriaId = plato.CategoriaId;
                    platoNuevo.Descripcion = plato.Descripcion;
                    platoNuevo.Precio = plato.Precio;

                    await _iservice.PostPlatos(platoNuevo);
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    ViewBag.Categorias = await GetCategorias();
                    return View();
                }
            }
            ViewBag.Categorias = await GetCategorias();
            return View();
        }

        // GET: PlatosController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var plato = await _iservice.GetPlatoPorID(id);

            List<PlatosViewModel> platosView = mapearViewPlato(new List<PlatosModel> { plato });

            return View(platosView.First());
        }

        // POST: PlatosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PlatosModel plato)
        {
            try
            {
                await _iservice.PutPlatos(plato);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatosController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var plato = await _iservice.GetPlatoPorID(id);

            List<PlatosViewModel> platosView = mapearViewPlato(new List<PlatosModel> { plato });

            return View(platosView.First());
        }

        // POST: PlatosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _iservice.DeletePlatos(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<PlatosViewModel> mapearViewPlato(List<PlatosModel> platos)
        {

            List<PlatosViewModel> platosAuxiliar = new List<PlatosViewModel>();

            foreach (PlatosModel plato in platos)
            {
                platosAuxiliar.Add(new PlatosViewModel
                {
                    Id = plato.Id,
                    Nombre = plato.Nombre,
                    Descripcion = plato.Descripcion,
                    Imagen = plato.Imagen,
                    Precio = plato.Precio,
                    CategoriaNombre = plato.Categoria.Nombre
                });
            }

            return platosAuxiliar;
        }


        private async Task<List<CategoriasModel>> GetCategorias()
        {
            List<CategoriasModel> categorias = await _iservice.GetCategorias();
            return categorias;
        }
    }

}
