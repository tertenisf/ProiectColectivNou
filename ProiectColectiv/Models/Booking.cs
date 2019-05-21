using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectColectiv.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [Display(Name = "De cand")]
        public DateTime Start_Time { get; set; }
        [Display(Name = "Pana cand")]
        public DateTime End_Time { get; set; }
        [Display(Name = "Numarul de inmatriculare")]
        public string PlateNumber { get; set; }

        public int Station_Id { get; set; }
        [Display(Name = "Vreti o statie FastCharging?")]
        public bool IsFastCharging { get; set; }
    }
}
