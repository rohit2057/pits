using System.ComponentModel.DataAnnotations;
using pits.Models;

namespace pits.Models
{
    public class ProfileM
    {

        [Key]
        public int Pid { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public String? Image { get; set; }


    }
}
