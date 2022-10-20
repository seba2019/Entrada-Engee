using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data
{
    public class Context 
    {
        private string _pathPersonas = "Data\\Personas.json";
        private string _pathVisitantes = "Data\\Visitante.json";
        public List<Persona> Personas { get; set; }
        public List<Visitante> Visitantes { get; set; }
        public Context() 
        {
            //personas
            string fullPathPersonas = Path.GetFullPath(_pathPersonas);
            string jsonPersonas = File.ReadAllText(fullPathPersonas);
            Personas = JsonConvert.DeserializeObject<List<Persona>>(jsonPersonas);

            //Visitantes
            string fullPathVisitantes = Path.GetFullPath(_pathVisitantes);
            string jsonVisitantes = File.ReadAllText(fullPathVisitantes);
            Visitantes = JsonConvert.DeserializeObject<List<Visitante>>(jsonVisitantes);
        }
    }
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Sector { get; set; }
    }

    public class Visitante
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string FechaNacimiento { get; set; }
        public string Dni { get; set; }
    }
}
