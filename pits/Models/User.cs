using System.ComponentModel.DataAnnotations;
using pits.Models;

namespace pits.Models
{
    public class User
    {
        [Key]
        public long UId { get; set; }
      

        public string? Name { get; set; }

        public string? Email { get; set; }
        [Required]

        public string? Password { get; set; }
        

        public long? Phone { get; set; }

        public string Address { get; set; }
    }
}
