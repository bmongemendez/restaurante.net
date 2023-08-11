using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Frontend_MVC.Models;
using Frontend_MVC.Models.ViewModels;
using Frontend_MVC.Services;

namespace Frontend_MVC.Controllers
{
    public class ReservasController : Controller
    {

        private readonly IService _iservice;


        public ReservasController(IService iservice)
        {
            _iservice = iservice;
        }

        // GET: ReservasController
        public async Task<IActionResult> Index()
        {
            List<ReservasViewModel> reservas = await _iservice.GetReservas();

            return View(reservas);
        }

        // GET: ReservasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReservasModel reserva)
        {
            try
            {
                await _iservice.PostReservas(reserva);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: ReservasController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var reserva = await _iservice.GetReservaPorID(id);

            return View(reserva);
        }

        // POST: ReservasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ReservasModel reserva)
        {
            try
            {
                await _iservice.PutReservas(reserva);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservasController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var reserva = await _iservice.GetReservaPorID(id);

            return View(reserva);
        }

        // POST: ReservasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _iservice.DeleteReservas(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
