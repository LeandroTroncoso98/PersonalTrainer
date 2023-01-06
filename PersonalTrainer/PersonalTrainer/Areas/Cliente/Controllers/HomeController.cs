using Microsoft.AspNetCore.Mvc;
using PersonalTrainer.Data.Repositorio;
using PersonalTrainer.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Slider = _contenedorTrabajo.Slider.GetAll()
            };
            return View(homeVM);
        }
    }
}
