using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Dolzhnost
    { 
        public int DolzhnostID { get; set; }
        public string Naimenovanie { get; set; }

        public ICollection<Sotrudnik> Sotrudnik { get; set; }

        public Dolzhnost()
        {
            Sotrudnik = new List<Sotrudnik>();
        }
    }
}