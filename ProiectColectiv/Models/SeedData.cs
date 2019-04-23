using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProiectColectiv.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProiectColectivContext(serviceProvider.GetRequiredService<DbContextOptions<ProiectColectivContext>>()))
            {
                if (context.User.Any())
                {
                    return;
                }

                context.User.AddRange(
                    new User
                    {
                        Name = "Ion",
                        Email = "aiaE@aiaE.com",
                        Password = "admin",
                        isAdmin = true
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
