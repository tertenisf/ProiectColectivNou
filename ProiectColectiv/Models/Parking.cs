using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectColectiv.Models
{
    public class Parking
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Longitudine { get; set; }

        public double Latitudine { get; set; }

        public int NrFastChargingSpots { get; set; }

        public int NrNormalChargingSpots { get; set; }
        
        public int MonthlyGain { get; set; }
        public int WeeklyGain { get; set; }
        public List<Station> Stations { get; set; }
        public bool isClosed { get; set; }
    }
}
