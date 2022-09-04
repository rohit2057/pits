using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using pits.data;
using pits.Models;
using System.Diagnostics;

namespace pits.Controllers
{
    public class HomeController : Controller


    {

        private ApplicationDbContext Context { get; }
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly INotyfService _notyf;


        public HomeController(ApplicationDbContext _context, IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            this.Context = _context;
            WebHostEnvironment = webHostEnvironment;
            _notyf = notyf;

        }

     


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NewLayout()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
            

            return RedirectToAction("Dashboard");
        }

        public IActionResult Message()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Message(Message m)
        {
            Context.Messages.Add(m);
            Context.SaveChanges();
            

            return RedirectToAction("Dashboard");
        }

        public IActionResult Login()
        {
            return View();
        }

     

    }
}