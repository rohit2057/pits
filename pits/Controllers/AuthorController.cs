using Microsoft.AspNetCore.Mvc;
using pits.data;
using pits.Models;
using System.Net;

namespace pits.Controllers
{
	public class AuthorController : Controller
	{
        private ApplicationDbContext Context { get; }

        public AuthorController(ApplicationDbContext _context)
        {
            this.Context = _context;
        }

        [HttpGet]
        public IActionResult Index()
		{
            //var viewModel = new Author()
            //{
            //    Id = Context.copy.Id,
            //    Name = Context.copy.Name,
            //};
            return View(Context.copy.ToList());
        }

        //[BindProperty]
        //public copy copy { get; set; }

        public IActionResult AddAuthor()
        {
            return View();
        }
		[HttpPost]
        public IActionResult AddAuthor(Author a)
        {
            var viewmodel = new Author()
            {
                Name = a.Name,
                Title = a.Title,
                Writer = a.Writer,

            };

            this.Context.copy.Add(viewmodel);
            this.Context.SaveChanges();

            return View(viewmodel);
        }

        //public IActionResult Author()
        //{

        //    return View(Context.copy.ToList());
        //}
    }

    public class copy
    {
    }
}
