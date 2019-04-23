using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProiectColectiv.Models;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProiectColectiv.Controllers
{
    public class RegisterController : Controller
    {

        private readonly ProiectColectivContext _context;

        public RegisterController(ProiectColectivContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            var user = new User();
            return View("~/Views/Home/Register.cshtml", user);
        }
        [HttpPost]
        public async Task<ActionResult> Register([Bind("Id, Name, Username, Password")] User user)
        {
            var users = await _context.User.FirstOrDefaultAsync(m => m.Email == user.Email);
            if (users == null || !user.Email.Equals(users.Email))
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return View("~/Views/Home/RegisterSuccess.cshtml");
            }
            return View("~/Views/Home/RegisterError.cshtml");


        }
    }
}