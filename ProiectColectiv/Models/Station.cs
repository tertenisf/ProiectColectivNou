using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectColectiv.Models
{
    public class Station
    {
        public int Id { get; set; }

        public int Id_Parking { get; set; }

        public bool IsFastCharging { get; set; }

        public bool isEmpty { get; set; }

        public string DailyGain { get; set; }

        public string WeeklyGain { get; set; }

        public string MonthlyGain { get; set; }
    }
}
