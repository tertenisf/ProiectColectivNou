using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace ProiectColectiv.Models
{
    public class ProiectColectivContext : DbContext
    {
        public ProiectColectivContext (DbContextOptions<ProiectColectivContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectColectiv.Models.User> User { get; set; }
        public DbSet<ProiectColectiv.Models.Station> Stations { get; set; }
        public DbSet<ProiectColectiv.Models.Parking> Parkings { get; set; }
    }
}
