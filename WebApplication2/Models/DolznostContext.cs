using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication2.Models
{
    public class DolznostContext : DbContext
    {
        public DbSet<Dolzhnost> Dolzhnost { get; set; }
        public DbSet<Sotrudnik> Sotrudnik { get; set; }
    }
}