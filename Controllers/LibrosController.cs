using Microsoft.AspNetCore.Mvc;
using proyectoCRUD.Data;
using proyectoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoCRUD.Controllers
{
    public class LibrosController : Controller
    {
        private readonly Data.AplicationDbContext _context;

        public LibrosController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            IEnumerable<Libro> listaLibros = _context.Libro;
            return View(listaLibros);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Crear-post
        [HttpPost]
        public IActionResult Create(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Add(libro);

                _context.SaveChanges();
            }

            TempData["mensaje"] = "Registro guardado exitosamente";

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            //Distinto a vacio
            if(id==null || id == 0)
            {
                return NotFound();
            }
            //Obtener libro
            var libro = _context.Libro.Find(id);

            //Evaluar identificador
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        //HTTP-post-edit
        [HttpPost]
        public IActionResult Edit(Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Libro.Update(libro);

                _context.SaveChanges();

                TempData["mensaje"] = "El registro se ha actualizado exitosamente";

                return RedirectToAction("Index");
            }

            return View();
        }

        //Eliminar
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var libro = _context.Libro.Find(id);

            if (libro == null) return NotFound();

            return View(libro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLibro(int? id)
        {
            var libro = _context.Libro.Find(id);

            if (libro == null) return NotFound();

            _context.Libro.Remove(libro);

            _context.SaveChanges();

            TempData["mensaje"] = "El registro se ha eliminado exitosamente";

            return RedirectToAction("Index");
        }

    }
}
