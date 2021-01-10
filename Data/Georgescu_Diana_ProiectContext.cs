using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Georgescu_Diana_Proiect.Models;

namespace Georgescu_Diana_Proiect.Data
{
    public class Georgescu_Diana_ProiectContext : DbContext
    {
        public Georgescu_Diana_ProiectContext (DbContextOptions<Georgescu_Diana_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Georgescu_Diana_Proiect.Models.Cloth> Cloth { get; set; }

        public DbSet<Georgescu_Diana_Proiect.Models.Size> Size { get; set; }

        public DbSet<Georgescu_Diana_Proiect.Models.Category> Category { get; set; }
    }
}
