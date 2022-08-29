using System.ComponentModel.DataAnnotations.Schema;

namespace pits.Models
{
   
    public class Author
    {
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Writer { get; set; }

        public int Isbn { get; set; }

    } 
}
