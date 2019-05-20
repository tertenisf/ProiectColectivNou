using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectColectiv.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

        public string PlateNumber { get; set; }
    }
}
