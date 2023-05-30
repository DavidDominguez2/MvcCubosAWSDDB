using Microsoft.AspNetCore.Mvc;
using MvcCubosAWSDDB.Models;
using MvcCubosAWSDDB.Repositories;
using System.Diagnostics;

namespace MvcCubosAWSDDB.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        private RepsitoryCubos repo;

        public HomeController(RepsitoryCubos repo) {
            this.repo = repo;
        }

        public async Task<IActionResult> Index() {
            return View(await this.repo.AllCubosAsync());
        }

        public async Task<IActionResult> Details(int id) {
            return View(await this.repo.GetCubo(id));
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo) {
            await this.repo.InsertCubo(cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Edit(int id) {
            return View(await this.repo.GetCubo(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cubo cubo) {
            await this.repo.UpdateCuboAsync(cubo.IdCubo, cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> Delete(int id) {
            await this.repo.DeleteCuboAsync(id);
            return RedirectToAction("Index", "Home");
        }

    }
}