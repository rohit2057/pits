using System.ComponentModel.DataAnnotations;
using pits.Models;

namespace pits.Models
{
    public class Message
    {
        [Key]
        public long MId { get; set; }


        public string? Name { get; set; }

        public string? Email { get; set; }
        [Required]

       


        public long? Phone { get; set; }

      
        public string? Messages { get; set; }
    }
}
