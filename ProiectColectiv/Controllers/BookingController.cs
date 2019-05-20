using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class BookingController : Controller
    {
        private readonly ProiectColectivContext _context;

        public BookingController(ProiectColectivContext context)
        {
            _context = context;
        }
        public ActionResult Booking(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Booking([Bind("Id, Start_Time, End_Time, PlateNumber")]
             Booking booking, int? id)
        {
            {
                if (ModelState.IsValid)
                {
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("UserMap", "UserMap");
                }

                return RedirectToAction("Booking", "Booking");
            }
        }
    }
}