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
                if (context.Parkings.Any())
                {
                    return;
                }

                context.Stations.AddRange(
                    new Station
                    {
                        IsFastCharging = true,
                        PlateNumber = "SV21SCN",
                        DailyGain = "120",
                        MonthlyGain = "350",
                        WeeklyGain = "150"
                    },
                    new Station
                    {
                        IsFastCharging = false,
                        PlateNumber = "SV20SCN",
                        DailyGain = "130",
                        MonthlyGain = "450",
                        WeeklyGain = "250"
                    },
                    new Station
                    {
                        IsFastCharging = false,
                        PlateNumber = "SV18SCN",
                        DailyGain = "200",
                        MonthlyGain = "550",
                        WeeklyGain = "350"
                    }
                    );
                context.Parkings.AddRange(
                    new Parking
                    {
                        Name = "Manastur",
                        Latitudine = 46.753712,
                        Longitudine = 23.563520,
                        NrNormalChargingSpots = 12,
                        NrFastChargingSpots = 6
                    },
                    new Parking
                    {
                        Name = "Clinicilor",
                        Latitudine = 46.765220,
                        Longitudine = 23.580070,
                        NrFastChargingSpots = 7,
                        NrNormalChargingSpots = 7,
                    },
                      new Parking
                      {
                          Name = "Unirii",
                          Latitudine = 46.753712,
                          Longitudine = 23.563520,
                          NrFastChargingSpots = 5,
                          NrNormalChargingSpots = 5,
                      },
                new Parking
                {
                    Name = "Campului",
                    Latitudine = 46.746490,
                    Longitudine = 23.569220,
                    NrNormalChargingSpots = 12,
                    NrFastChargingSpots = 6
                },
                    new Parking
                    {
                        Name = "Septimiu Albini",
                        Latitudine = 46.765010,
                        Longitudine = 23.611470,
                        NrNormalChargingSpots = 12,
                        NrFastChargingSpots = 6
                    }
                    );
                context.User.AddRange(
                    new User
                    {
                        Name = "Ion",
                        Email = "aiaE@aiaE.com",
                        Password = "admin",
                        isAdmin = false
                    },
                new User
                {
                    Name = "x",
                    Email = "xxxx@x.com",
                    Password = "admin",
                    isAdmin = false
                },
                new User
                {
                    Name = "Admin",
                    Email = "admin@admin.com",
                    Password = "admin",
                    isAdmin = true
                },
                new User
                {
                    Name = "gion",
                    Email = "Gion@Gion.com",
                    Password = "gion",
                    isAdmin = true
                }
                    );
                context.SaveChanges();
            }
        }
    }
}
