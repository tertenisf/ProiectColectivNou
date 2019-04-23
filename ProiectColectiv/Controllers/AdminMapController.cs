using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class AdminMapController : Controller
    {
        // GET
        public ActionResult AdminMap(User user)
        {
            return View("~/Views/Home/AdminMap.cshtml", user);
        }
    }
}