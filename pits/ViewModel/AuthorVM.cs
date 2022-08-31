using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace pits.ViewModel
{
    public class AuthorVM
    {

        [Key]
        public int Pid { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public  IFormFile Image { get; set; }

    }
}
