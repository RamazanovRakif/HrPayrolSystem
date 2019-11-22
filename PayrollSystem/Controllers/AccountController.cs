using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.DAL;
using PayrollSystem.Models;
using PayrollSystem.ViewModels;

namespace PayrollSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly PayrollDbContext _context;
        private readonly UserManager<Worker> _userManager;
        private readonly SignInManager<Worker> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(PayrollDbContext context, UserManager<Worker> userManager, SignInManager<Worker> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult AccessDenied()
        {
            return Content("Boom!!!!");
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var data = await _userManager.FindByEmailAsync(login.Email);

            if (data == null)
            {
                ModelState.AddModelError("", "Email or Password is wrong!!");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(data, login.Password, login.RememberMe, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or Password is wrong!!");
                return View(login);
            }

            return Redirect("/Main/Contact");

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Account/Login");
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgetPassword(LoginVM login)
        {
            var data = await _userManager.FindByEmailAsync(login.Email);

            SmtpClient cl = new SmtpClient("smtp.gmail.com", 587);
            cl.Credentials = new NetworkCredential("rakiframazanov11@gmail.com", "Sevgilimvemen");
            cl.DeliveryMethod = SmtpDeliveryMethod.Network;
            cl.UseDefaultCredentials = false;
            cl.EnableSsl = true;

            MailMessage mailMessage = new MailMessage();
            mailMessage.To.Add(data.Email);
            mailMessage.From = new MailAddress("rakiframazanov11@gmail.com");

            mailMessage.Subject = "Your password...";
            mailMessage.Body = data.PassText;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            cl.Send(mailMessage);
            mailMessage.IsBodyHtml = true;

            return RedirectToAction(nameof(Login));
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(PasswordViewModel changePassword)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => _userManager.FindByNameAsync(User.Identity.Name).GetAwaiter().GetResult().Id == x.Id);
            var email = user.Email;
            user.PassText = changePassword.Password;

            IdentityResult result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.Password);

            return RedirectToAction("Contact", "Main");
        }

    }
}