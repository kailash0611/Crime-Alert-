using CrimeAlert.Models;
using CrimeAlert.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;


namespace CrimeAlert.Controllers
{
    public class SignupLoginController : Controller


    {
        //ApplicationDBContext _context;
        private readonly ApplicationDBContext _context;
        public SignupLoginController(ApplicationDBContext context)
        {
            _context = context;
        }

        [Route("login")]
       
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(LoginSignupViewModel model)
        {
            //_context = context;

            if (ModelState.IsValid)
            {
                var data = _context.Admin_Signups.Where(e => e.UserName == model.UserName).SingleOrDefault();
                if (data != null)

                {
                    bool isValid = (data.UserName == model.UserName && data.Password == model.Password);
                    if (isValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.UserName) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principle = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                        HttpContext.Session.SetString("Username", model.UserName);

                        CookieOptions cookie = new CookieOptions();
                        cookie.Expires = DateTime.Now.AddDays(1);
                        Response.Cookies.Append("UserName", model.UserName, cookie);
                        string userName = (Request.Cookies["UserName"]);
                        //var a = _context.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();

                        if (data.IsAdmin == 1 )
                        {
                            return RedirectToAction("AdminHome", "Home");
                        }
                        else
                        {
                            return RedirectToAction("UserHome", "Home");
                        }
                    }
                    else
                    {
                        TempData["errorMessage"] = "Username & Password do not match!";
                        return View("Login");

                    }
                }
                else
                {
                    TempData["errorMessage"] = "Username not found!";
                    return View("Login");
                }
            }
            else
            {
                TempData["errorMessage"] = "Invalid Credentials!";
                return View("Login");
            }

        }
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "SignupLogin");
        }
        [Route("signup")]

        public IActionResult Signup()
        {
            return View();
        }


        [HttpPost]
        //[ActionName("signup")]
        public IActionResult Signup1(LoginSignupViewModel models)
        {
            if (_context.Admin_Signups.Any(user => user.UserName == models.UserName || user.EmailId == models.EmailId))
            {

                TempData["errorMessage"] = "A user with the same UserName or Email already exists!";
                return View("Signup");
            }

            var user = new admin_signup
            {
                UserName = models.UserName,
                EmailId = models.EmailId,
                PhoneNo = models.PhoneNo,
                FullName = models.FullName,
                Password = models.Password,
                ConfirmPassword = models.ConfirmPassword,
                IsAdmin = models.IsAdmin
            };
            _context.Admin_Signups.Add(user);
            _context.SaveChanges();




            return RedirectToAction("Login");


        }
    }
}
