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

namespace Web.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly List<Personas> _listPersonas;
        private readonly List<Renaper> _renapers;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly List<VisitasVm> _listVisitasRandom;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _listVisitasRandom = new List<VisitasVm>();
            string pathJsonPersonas = Path.Combine(_webHostEnvironment.ContentRootPath, "Data/Personas.json");
            string pathJsonRenaper = Path.Combine(_webHostEnvironment.ContentRootPath, "Data/Renaper.json");

            using (StreamReader jsonStreamPersonas = System.IO.File.OpenText(pathJsonPersonas))
            {
                var jsonPersonas = jsonStreamPersonas.ReadToEnd();
                _listPersonas = JsonConvert.DeserializeObject<List<Personas>>(jsonPersonas);
            }

            using (StreamReader jsonStreamRenaper = System.IO.File.OpenText(pathJsonRenaper))
            {
                var jsonRenaper = jsonStreamRenaper.ReadToEnd();
                _renapers = JsonConvert.DeserializeObject<List<Renaper>>(jsonRenaper);
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
                    PersonaVisitada = $"{persona.Nombre} {persona.Apellido}",
                    Hora = DateTime.Today.ToShortTimeString(),
                    Fecha = DateTime.Today.Date.ToShortDateString()
                };
                _listVisitasRandom.Add(visita);
            }
        }

        public IActionResult Index()
        {
            return View(_listVisitasRandom);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
