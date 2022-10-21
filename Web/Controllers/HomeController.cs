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

        private Context _context;
        private List<VisitasVm> _listVisitas;

        public HomeController(Context context)
        {
            _context = context;
            List<VisitasVm> listVisitas = new List<VisitasVm>();
            foreach (HistorialVisitas visitas in _context.HistorialVisitas)
            {
                VisitasVm visitasVm = new VisitasVm()
                {
                    Nombre = visitas.Nombre,
                    Apellido = visitas.Apellido,
                    Fecha = visitas.Fecha,
                    Hora = visitas.Hora,
                    Id = visitas.id,
                    Visito = visitas.Visito
                };
                listVisitas.Add(visitasVm);
            }
            _listVisitas = listVisitas;
        }

        public IActionResult Index()
        {
            var sectores = _context.Personas.Select(g => g.Sector).Distinct().ToList();
   
            ViewData["sectores"] = sectores;
            HomeVm model = new HomeVm()
            {
                Visita = new VisitasVm(),
                ListVisitas = _listVisitas
            };

            return View(model);
        }

        public IActionResult AddVisita(VisitasVm visita)
        {

            if (!ModelState.IsValid) 
            {
                ViewData["errorMsg"] = "Datos incorrectos";
                return PartialView("_ListadoIngresos.cshtml", _listVisitas);
            }

            visita.Id = _listVisitas.Last().Id + 1;
            HistorialVisitas historialVisitas = new HistorialVisitas()
            {
                id = visita.Id,
                Nombre = visita.Nombre,
                Apellido = visita.Apellido,
                Fecha = visita.Fecha,
                Hora = visita.Hora,
                Visito = visita.Visito
            };
            _context.HistorialVisitas.Add(historialVisitas);
            _context.Save();

            return PartialView("_ListadoIngresos.cshtml", _listVisitas);
        }

        public IActionResult DeleteVisita(int id)
        {
            HistorialVisitas historialVisitas = _context
                                                .HistorialVisitas
                                                .Where(w => w.id == id)
                                                .FirstOrDefault();

            _context.HistorialVisitas.Remove(historialVisitas);
            _context.Save();
            VisitasVm visitas = _listVisitas.Where(w => w.Id == id).FirstOrDefault();
            _listVisitas.Remove(visitas);
            return PartialView("_ListadoIngresos", _listVisitas);
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

        public IActionResult Notify(string msg, string type)
        {
            Notification notification = new Notification() 
            {
                Message = msg,
                Type = type
            };
            return PartialView("_Notifications",notification);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
