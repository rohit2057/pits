using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pits.data;
using pits.Models;
using pits.ViewModel;
using System.Net;

namespace pits.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDbContext Context { get; }
        private readonly IWebHostEnvironment WebHostEnvironment;
        private readonly INotyfService _notyf;
        

        public AuthorController(ApplicationDbContext _context , IWebHostEnvironment webHostEnvironment, INotyfService notyf)
        {
            this.Context = _context;
            WebHostEnvironment = webHostEnvironment;
                _notyf = notyf;
            
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
            _notyf.Success("Success Notification");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Author auth = Context.copy.Find(id);
            Context.Entry(auth).State = EntityState.Deleted;
            Context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var authors = Context.copy.Find(id);

            return View(authors);

        }

        [HttpPost]
        public IActionResult Update(Author a)
        {
            //Context.Entry(a).State = EntityState.Modified;
            Context.copy.Update(a);
            Context.SaveChanges();
            _notyf.Success("Update Notification");
            return RedirectToAction("Index");

        }

        public IActionResult Profile()
        {


            return View(Context.image.ToList());
        }


        public IActionResult AddProfile() {
            return View();
        }
        [HttpPost]
        public IActionResult AddProfile(AuthorVM p)
        {
            string StringFileUrl = Upload(p);

            var data = new ProfileM
            {
                Name = p.Name,
                Email = p.Email,
                Phone = p.Phone,
                Address = p.Address,
                Image = StringFileUrl,

            };
            Context.image.Add(data);
            Context.SaveChanges();

            return RedirectToAction("Profile");
            
        }

        public string Upload(AuthorVM img)
        {
            string filename = "";
            if(img.Image != null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "image");
                filename = Guid.NewGuid().ToString() + "-" + img.Image.FileName;
                string filePath = Path.Combine(uploadDir, filename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    img.Image.CopyTo(fileStream);
                }
            }
            return filename;
        }


        [HttpGet]
        public IActionResult Message()
        {
            //var viewModel = new Author()
            //{
            //    Id = Context.copy.Id,
            //    Name = Context.copy.Name,
            //};
            return View(Context.Messages.ToList());
        }




    }
}
