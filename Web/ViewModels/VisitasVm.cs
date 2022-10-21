using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class VisitasVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        [MaxLength(8)]
        public string Dni { get; set; }
        
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(8)]
        public string NroTarjetaIngreso { get; set; }
        public string Visito { get; set; }
    }
}
