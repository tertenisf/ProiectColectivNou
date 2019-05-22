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
                //string sMonth = DateTime.Now.ToString("MM");
                int monthNow = DateTime.Today.Month;
                int yearNow = DateTime.Today.Year;
                int hourNow = DateTime.Now.Hour;
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
                        TimeSpan difference = booking.End_Time  - booking.Start_Time;
                        double hours = difference.TotalHours;
                        int month = booking.Start_Time.Month;
                        int year = booking.Start_Time.Year;
                        int hour = booking.Start_Time.Hour;

                        if (month == monthNow)
                        {
                            parkings.MonthlyGain = parkings.MonthlyGain+(int)hours * 2;                            
                        }

                        if (year == yearNow)
                        {
                            parkings.WeeklyGain = parkings.WeeklyGain+(int)hours * 2;
                        }

                        if (hour-hourNow <=1)
                        {
                            parkings.NrFastChargingSpots -= 1; 

                        }    
                        
                        _context.Parkings.Update(parkings);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        TimeSpan difference = booking.End_Time - booking.Start_Time;
                        double hours = difference.TotalHours;
                        int month = booking.Start_Time.Month;
                        int year = booking.Start_Time.Year;
                        int hour = booking.Start_Time.Hour;

                        if (month == monthNow)
                        {
                            parkings.MonthlyGain = (int)hours ;
                        }

                        if (year == yearNow)
                        {
                            parkings.WeeklyGain = (int)hours;
                        }
                        if (hour - hourNow <= 1)
                        {
                            parkings.NrNormalChargingSpots -= 1;

                        }

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