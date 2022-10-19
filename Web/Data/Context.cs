using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data
{
    public class Persona
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly List<Persona> _listPersonas;
        public Persona(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            string pathJsonPersonas = Path.Combine(_webHost.ContentRootPath, "Data/Personas.json");
            using (StreamReader jsonStreamPersonas = System.IO.File.OpenText(pathJsonPersonas))
            {
                var jsonPersonas = jsonStreamPersonas.ReadToEnd();
                _listPersonas = JsonConvert.DeserializeObject<List<Persona>>(jsonPersonas);
            }
        }
        public List<Persona> Personas
        {
            get
            {
                return _listPersonas;
            }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sector { get; set; }

    }

    public class Renaper
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly List<Renaper> _renapers;
        public Renaper(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
            string pathJsonRenaper = Path.Combine(_webHost.ContentRootPath, "Data/Visitante.json");
            using (StreamReader jsonStreamRenaper = System.IO.File.OpenText(pathJsonRenaper))
            {
                var jsonRenaper = jsonStreamRenaper.ReadToEnd();
                _renapers = JsonConvert.DeserializeObject<List<Renaper>>(jsonRenaper);
            }
        }
        public List<Renaper> Renapers
        {
            get { return _renapers; }
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Dni { get; set; }
    }
}
