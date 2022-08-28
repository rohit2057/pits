using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //var viewmodel = new Author()
            //{
            //    Id = a.Id,
            //    Name = a.Name,
            //    Title = a.Title,
            //    Writer = a.Writer,

            //};

            Context.copy.Add(a);
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            Author auth = Context.copy.Find(id);
            Context.Entry(auth).State = EntityState.Deleted;
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(string id)
        {
            Author authors = Context.copy.Find(id);
            return View(authors);

        }

        [HttpPost]
        public IActionResult Update(Author a)
        {
            Context.Entry(a).State = EntityState.Modified;
            Context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
