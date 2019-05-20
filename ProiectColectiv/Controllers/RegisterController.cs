using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProiectColectiv.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult> Register([Bind("Id, Email, Password, Name")] User user)
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