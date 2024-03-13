using ASP.NET.Datos;
using ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _Contexto;

        public HomeController(Context Contexto)
        {
            _Contexto = Contexto;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _Contexto.Alumno.ToListAsync());
        }







        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                alumno.FechaRegistro = DateTime.Now;
                _Contexto.Alumno.Add(alumno);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Editar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _Contexto.Alumno.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _Contexto.Alumno.Update(alumno);
                await _Contexto.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detalle(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _Contexto.Alumno.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            else
            {
                return View(alumno);
            }
        }


        public IActionResult Eliminar(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = _Contexto.Alumno.Find(id);
            if (alumno == null)
            {
                return NotFound();
            }
            else
            {
                return View(alumno);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarAlumno(int id)
        {
            var alumno = _Contexto.Alumno.Find(id);

            if(id == null)
            {
                return View();  

            }

            _Contexto.Alumno.Remove(alumno);
            await _Contexto.SaveChangesAsync();

            return RedirectToAction("Index");

        }









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
