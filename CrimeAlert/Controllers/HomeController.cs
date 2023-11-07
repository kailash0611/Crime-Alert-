using CrimeAlert.Models;
using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace CrimeAlert.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _dbContext;

        public HomeController( ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("home")]
        [Route("/")]
        [AllowAnonymous]
        public IActionResult Home()
        {
            return View();
        }
        [Route("aboutus")]
        public IActionResult AboutUs()
        {
            string userName = (Request.Cookies["UserName"]);
            var a = _dbContext.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return View();
        }

        [Route("Admin_home")]
        public IActionResult AdminHome(user_crimeAlert model)
        {
            string userName = (Request.Cookies["UserName"]);
            var a = _dbContext.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return View();
        }
        [Route("User_home")]
        public IActionResult UserHome()
        {
            string userName = (Request.Cookies["UserName"]);
            var a = _dbContext.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return View();
        }

        [Route("Dashboard")]
        public IActionResult dashboard()
        {
            IEnumerable<user_crimeAlert> list = _dbContext.User_Crimealerts.ToList();
            string userName = (Request.Cookies["UserName"]);
            var a = _dbContext.Admin_Signups.Where(x => x.UserName == userName).Select(X => X).First();
            ViewData["isAdmin"] = a.IsAdmin;
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}