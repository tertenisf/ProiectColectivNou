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
        public async Task<IActionResult> Booking([Bind("Id, Start_Time, End_Time, PlateNumber,IsFastCharging")]
             Booking booking, int? id)
        {
            {
                booking.Station_Id = id.Value;

                var book = await _context.Booking.FirstOrDefaultAsync(m => m.Station_Id == booking.Station_Id && m.PlateNumber == booking.PlateNumber && !CheckDates(booking, m.Start_Time, m.End_Time));
                var lastBookingId = await _context.Booking.LastOrDefaultAsync();
                var parkings = await _context.Parkings.FirstOrDefaultAsync(x => x.Id == id);
                booking.Id = lastBookingId.Id + 1;

                if (book == null || !booking.Station_Id.Equals(book.Station_Id))
                {
                    _context.Add(booking);
                    await _context.SaveChangesAsync();
                    if (booking.IsFastCharging)
                    {
                        parkings.NrFastChargingSpots -= 1;
                        _context.Parkings.Update(parkings);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        parkings.NrNormalChargingSpots -= 1;
                        _context.Parkings.Update(parkings);
                        await _context.SaveChangesAsync();
                    }                    
                    return View("~/Views/Home/BookingSuccess.cshtml", booking);
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