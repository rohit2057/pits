using System.ComponentModel.DataAnnotations.Schema;

namespace pits.Models
{
    [Table("Author", Schema="public")]
    public class Author
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Writer { get; set; }

    } 
}
