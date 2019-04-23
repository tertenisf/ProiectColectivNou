using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Models;
using System.Threading.Tasks;

namespace ProiectColectiv.Controllers
{
    public class LoginController : Controller
    {
        private readonly ProiectColectivContext _context;

        public LoginController(ProiectColectivContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Login()
        {
            var user = new User();
            return View("~/Views/Home/Login.cshtml", user);
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Id, Name, Username, Password")] User user)
        {
            var users = await _context.User.FirstOrDefaultAsync(m => m.Email == user.Email);
            if (users != null && users.isAdmin == true && user.Email.Equals(users.Email) && user.Password.Equals(users.Password))
            {
                return RedirectToAction("AdminMap", "AdminMap", users);
            }
            if (users != null && user.isAdmin == false && user.Email.Equals(users.Email) && user.Password.Equals(users.Password))
            {
                return RedirectToAction("UserMap", "UserMap", users);
            }

            return View("~/Views/Home/LoginError.cshtml");
        }
    }
}