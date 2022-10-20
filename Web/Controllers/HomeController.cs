using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Web.ViewModels;
using System.Linq;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly List<VisitasVm> _historialVisitas;
        private Context _context;

        public HomeController(Context context)
        {
            _context = context;
            Random rd = new Random();
            int posRandom = 0;
            Persona persona = new Persona();
            _historialVisitas = new List<VisitasVm>();
            for (int i = 0; i < 10; i++)
            {
                posRandom = rd.Next(0, _context.Personas.Count - 1);
                persona = _context.Personas[posRandom];
                VisitasVm visita = new VisitasVm()
                {
                    Id = i + 1,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Hora = DateTime.Now.AddMinutes(-i).ToString("HH:mm"),
                    Fecha = DateTime.Today.Date.ToShortDateString()
                };
                _historialVisitas.Add(visita);
            }
        }

        public IActionResult Index()
        {
            var sectores = _context.Personas.Select(g => g.Sector).Distinct().ToList();

            ViewData["sectores"] = sectores;
            HomeVm model = new HomeVm()
            {
                Visita = new VisitasVm(),
                ListVisitas = _historialVisitas
            };
            return View(model);
        }

        public IActionResult AddVisita(VisitasVm visita)
        {
            List<VisitasVm> visitas = _historialVisitas;
            visitas.Add(visita);
            return PartialView("_ListadoIngresos.cshtml",visitas);
        }

        public IActionResult DeleteVisita(int id)
        {
            VisitasVm visita = _historialVisitas.Where(w => w.Id == id).FirstOrDefault();
            _historialVisitas.Remove(visita);
            return PartialView("_ListadoIngresos.cshtml", visita);
        }

        public JsonResult GetVisitante(string dni) 
        {
            Visitante visitante = _context.Visitantes.Where(w => w.Dni == dni).FirstOrDefault();
            return Json(visitante);
        }
        public JsonResult GetPersonasBySector(string sector)
        {
            var personas = _context.Personas
                                .Where(p => p.Sector == sector)
                                .Select(s => new { Nombre = s.Nombre, Apellido = s.Apellido })
                                .ToList();
            return Json(personas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
