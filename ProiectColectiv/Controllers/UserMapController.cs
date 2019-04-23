using Microsoft.AspNetCore.Mvc;
using ProiectColectiv.Models;

namespace ProiectColectiv.Controllers
{
    public class UserMapController : Controller
    {
        // GET
        public ActionResult UserMap(User user)
        {
            return View("~/Views/Home/UserMap.cshtml", user);
        }
    }
}