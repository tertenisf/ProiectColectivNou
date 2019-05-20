using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class UserMapController : Controller
    {
        private readonly ProiectColectivContext _context;

        public UserMapController(ProiectColectivContext context)
        {
            _context = context;
        }
        // GET
        public ActionResult UserMap(User user)
        {
            return View("~/Views/Home/UserMap.cshtml", user);
        }
        public JsonResult GetAllLocation()
        {
            var data = _context.Parkings.ToList();
            return Json(data);
        }
        [HttpPost]
        public void BookingNormal(int? id)
        {
            var data = _context.Parkings.Where(m => m.Id == id).SingleOrDefault();
            if (data.NrNormalChargingSpots != 0)
            {
                data.NrNormalChargingSpots -=1;
            }
            _context.Parkings.Update(data);
            _context.SaveChanges();
        }
        [HttpPost]
        public void BookingFast(int? id)
        {
            var data = _context.Parkings.Where(m => m.Id == id).SingleOrDefault();
            if (data.NrFastChargingSpots != 0)
            {
                data.NrFastChargingSpots -= 1;
            }
            _context.Parkings.Update(data);
            _context.SaveChanges();
        }
    }
}