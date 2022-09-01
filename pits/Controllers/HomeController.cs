using Microsoft.AspNetCore.Mvc;
using pits.data;
using pits.Models;
using System.Diagnostics;

namespace pits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

     

        //[HttpPost]
        //public IActionResult Index(Book b)
        //{
        //    var viewModel = new Book()
        //    {
        //        Id = b.Id,
        //        Name = b.Name,
        //        Author = b.Author
        //    };

        //    this.Context.copy.Add(viewModel);
        //    this.Context.SaveChanges();

        //    //return View(viewModel);
        //    //ViewBag.Greet = "hello";
        //    return View(viewModel);
        //}

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
    }
}