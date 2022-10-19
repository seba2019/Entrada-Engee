using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class HomeVm
    {
        public VisitasVm Visita { get; set; }
        public List<VisitasVm> ListVisitas { get; set; }
    }
}
