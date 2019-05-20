using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                booking.StationId = id.Value;

                var book = await _context.Booking.FirstOrDefaultAsync(m => m.StationId == booking.StationId && m.PlateNumber == booking.PlateNumber && !CheckDates(booking, m.Start_Time, m.End_Time));
                var lastBookingId = await _context.Booking.LastOrDefaultAsync();
                booking.Id = lastBookingId.Id + 1;

                if (book == null || !booking.StationId.Equals(book.StationId))
                {
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction("UserMap", "UserMap", new { callbackSuccess = 1 });
                }

                return RedirectToAction("Booking", "Booking", new { id = id.Value });
            }
        }

        private bool CheckDates(Booking bookingReq, DateTime startDate, DateTime endDate)
        {
            return (bookingReq.Start_Time < startDate && bookingReq.End_Time < startDate) ||
                    (bookingReq.Start_Time > endDate && bookingReq.End_Time > endDate);
        }
    }
}