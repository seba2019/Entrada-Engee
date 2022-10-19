using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Web.ViewModels;
using System.Linq;

namespace Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly List<Personas> _listPersonas;
        private readonly List<Visitante> _visitantes;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly List<VisitasVm> _listVisitasRandom;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _listVisitasRandom = new List<VisitasVm>();
            string pathJsonPersonas = Path.Combine(_webHostEnvironment.ContentRootPath, "Data/Personas.json");
            string pathJsonVisitante = Path.Combine(_webHostEnvironment.ContentRootPath, "Data/Visitante.json");

            using (StreamReader jsonStreamPersonas = System.IO.File.OpenText(pathJsonPersonas))
            {
                var jsonPersonas = jsonStreamPersonas.ReadToEnd();
                _listPersonas = JsonConvert.DeserializeObject<List<Personas>>(jsonPersonas);
            }

            using (StreamReader jsonStreamVisitante = System.IO.File.OpenText(pathJsonVisitante))
            {
                var jsonVisitante = jsonStreamVisitante.ReadToEnd();
                _visitantes = JsonConvert.DeserializeObject<List<Visitante>>(jsonVisitante);
            }


            Random rd = new Random();
            int posRandom = 0;
            Personas persona = new Personas();

            for (int i = 0; i < 10; i++)
            {
                posRandom = rd.Next(0, _listPersonas.Count - 1);
                persona = _listPersonas[posRandom];
                VisitasVm visita = new VisitasVm()
                {
                    Id = i + 1,
                    Nombre = persona.Nombre,
                    Apellido = persona.Apellido,
                    Hora = DateTime.Today.ToShortTimeString(),
                    Fecha = DateTime.Today.Date.ToShortDateString()
                };
                _listVisitasRandom.Add(visita);
            }
        }

        public IActionResult Index()
        {
            var sectores = _listPersonas.Select(g => g.Sector).Distinct().ToList();
            
            ViewData["sectores"] = sectores;
            HomeVm model = new HomeVm()
            {
                Visita = new VisitasVm(),
                ListVisitas = _listVisitasRandom
            };
            return View(model);
        }

        public IActionResult AgregarVisita(VisitasVm visita)
        {
            List<VisitasVm> visitas = _listVisitasRandom;
            visitas.Add(visita);
            return PartialView("_ListadoIngresos.cshtml",visitas);
        }

        public JsonResult GetVisitante(string dni) 
        {
            Visitante visitante = _visitantes.Where(w => w.Dni == dni).FirstOrDefault();
            return Json(visitante);
        }
        public JsonResult GetPersonasBySector(string sector)
        {
            var personas = _listPersonas
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
