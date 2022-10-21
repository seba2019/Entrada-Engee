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
        private string _pathVisitas = "Data\\HistorialVisitas.json";
        public List<Persona> Personas { get; set; }
        public List<Visitante> Visitantes { get; set; }
        public List<HistorialVisitas> HistorialVisitas { get; set; }
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

            //Historial Visitas
            string fullPathVisitas = Path.GetFullPath(_pathVisitas);
            string jsonVisitas = File.ReadAllText(fullPathVisitas);
            HistorialVisitas = JsonConvert.DeserializeObject<List<HistorialVisitas>>(jsonVisitas);
        }
        public void Save() 
        {
            string path = Path.GetFullPath(_pathVisitas);
            string json = JsonConvert.SerializeObject(HistorialVisitas);
            File.WriteAllText(path, json);
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

    public class HistorialVisitas 
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Visito { get; set; }
    }
}
