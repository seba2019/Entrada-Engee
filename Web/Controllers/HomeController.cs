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

namespace Web.Controllers
{
    public class HomeController : Controller
    {
  
        private readonly List<Personas> __listPersonas;
        private readonly List<Renaper> _renapers;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            string pathJsonPersonas = Path.Combine(_webHostEnvironment.WebRootPath, "Data/Personas.json");
            string pathJsonRenaper = Path.Combine(_webHostEnvironment.WebRootPath, "Data/Renaper.json");

            using (StreamReader jsonStreamPersonas = System.IO.File.OpenText(pathJsonPersonas))
            {
                var jsonPersonas = jsonStreamPersonas.ReadToEnd();
                __listPersonas = JsonConvert.DeserializeObject<List<Personas>>(jsonPersonas);
            }

            using (StreamReader jsonStreamRenaper = System.IO.File.OpenText(pathJsonRenaper))
            {
                var jsonRenaper = jsonStreamRenaper.ReadToEnd();
                _renapers = JsonConvert.DeserializeObject<List<Renaper>>(jsonRenaper);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
