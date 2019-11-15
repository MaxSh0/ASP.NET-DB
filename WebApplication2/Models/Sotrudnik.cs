using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Sotrudnik
    {
        public int ID_Rabotnika { get; set; }
        public string Imya { get; set; }
        public string Familiya { get; set; }
        public int Vysluga { get; set; }
        public int Vozrast { get; set; }

        public int? DolzhnostID { get; set; }
        public Dolzhnost Dolzhnost { get; set; }
    }
}