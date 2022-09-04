using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pits.data;
using pits.Models;
using pits.ViewModel;
using System.Net;
using System.Xml.Linq;

namespace pits.Controllers
{
    public class AuthorController : Controller
    {
        private ApplicationDbContext Context { get; }
        public int PId { get; private set; }

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

            return View(Context.copy.ToList());
        }

  

        public IActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAuthor(Author a)
        {
   

            Context.copy.Add(a);
            Context.SaveChanges();
            _notyf.Success("Successfully added");

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Author auth = Context.copy.Find(id);
            Context.Entry(auth).State = EntityState.Deleted;
            Context.SaveChanges();
            _notyf.Success("Successfully Deleted");
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
            
            Context.copy.Update(a);
            Context.SaveChanges();
            _notyf.Success("successfully updated");
            return RedirectToAction("Index");

        }

        public IActionResult Profile()
        {

            
            int max = Context.image.Max(p => p.Pid);
            return View(Context.image.Find(max));
           
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
       
            return View(Context.Messages.ToList());
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            //var UserData = Context.Users.FirstOrDefault(u => u.Email == user.Email);
            var data = Context.Users.ToList();
            foreach (var item in data)
            {
                if (user.Email == item.Email)
                {
                    bool verified =(user.Password == item.Password);
                    if (verified == true)
                    {
                        _notyf.Success("Login success");
                        return Redirect("https://localhost:7133/Home/NewLayout");
                    }
                    else
                    {
                        Redirect("https://localhost:7133/");
                    }
                }
                else
                {
                    return Redirect("https://localhost:7133/");
                }
             
            }
            return Redirect("https://localhost:7133/");

        }



    }
}
