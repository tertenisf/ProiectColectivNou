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
        [HttpPost]
        public void GetAllLocationStatusById(int? id)
        {
            var data = _context.Parkings.Where(m => m.Id == id).SingleOrDefault();
            if (data.isClosed)
            {
                data.isClosed = false;
            }
            else
            {
                data.isClosed = true;
            }

            _context.Parkings.Update(data);
            _context.SaveChanges();
        }
    }
}