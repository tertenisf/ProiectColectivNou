using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class AdminMapController : Controller
    {
        private readonly ProiectColectivContext _context;

        public AdminMapController(ProiectColectivContext context)
        {
            _context = context;
        }

        public ActionResult AdminMap(User user)
        {
            return View("~/Views/Home/AdminMap.cshtml", user);
        }
       
        public JsonResult GetAllLocation()
        {
            var data = _context.Parkings.ToList();
            return Json(data);
        }
    }
}