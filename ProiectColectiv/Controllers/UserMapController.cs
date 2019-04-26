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
    }
}