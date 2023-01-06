using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PersonalTrainer.Data;
using PersonalTrainer.Data.Repositorio;
using PersonalTrainer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalTrainer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public SliderController(IContenedorTrabajo contenedorTrabajo, IWebHostEnvironment hostEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Funcion ejecutada desde el js que contiene index
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Slider.GetAll() });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaDelArchivoEnProg = _hostingEnvironment.WebRootPath;
                var archivoEnPc = HttpContext.Request.Form.Files;

                string nombreDelArchivo = Guid.NewGuid().ToString();
                var subida = Path.Combine(rutaDelArchivoEnProg, @"imagenes\sliders");
                var extension = Path.GetExtension(archivoEnPc[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(subida, nombreDelArchivo + extension), FileMode.Create))
                {
                    archivoEnPc[0].CopyTo(fileStream);
                }
                slider.ImagenUrl = @"\imagenes\sliders\" + nombreDelArchivo + extension;
                _contenedorTrabajo.Slider.add(slider);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                var slider = _contenedorTrabajo.Slider.Get(id.GetValueOrDefault());
                return View(slider);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                var sliderDesdeDb = _contenedorTrabajo.Slider.Get(slider.Id);
                string rutaDelArchivoProg = _hostingEnvironment.WebRootPath;
                var archivoEnPc = HttpContext.Request.Form.Files;

                if (archivoEnPc.Count() > 0)
                {
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaDelArchivoProg, @"imagenes\sliders");
                    var nuevaExtension = Path.GetExtension(archivoEnPc[0].FileName);
                    var rutaImagen = Path.Combine(rutaDelArchivoProg, sliderDesdeDb.ImagenUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + nuevaExtension), FileMode.Create))
                    {
                        archivoEnPc[0].CopyTo(fileStreams);
                    }
                    slider.ImagenUrl = @"\imagenes\sliders\" + nombreArchivo + nuevaExtension;
                    _contenedorTrabajo.Slider.Update(slider);
                    _contenedorTrabajo.Save();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    slider.ImagenUrl = sliderDesdeDb.ImagenUrl;
                }
                _contenedorTrabajo.Slider.Update(slider);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(slider);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var slider = _contenedorTrabajo.Slider.Get(id);
            if(slider == null)
            {
                return Json(new { success = false, message = "Error borrando articulo" });
            }
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImagen = Path.Combine(rutaDirectorioPrincipal, slider.ImagenUrl.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }
            _contenedorTrabajo.Slider.Remove(slider);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Eliminado con exito." });
        }
    }
}
