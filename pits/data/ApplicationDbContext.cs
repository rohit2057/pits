using Microsoft.EntityFrameworkCore;
using pits.Models;

namespace pits.data
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Author> copy { get; set; }
        public DbSet<ProfileM> image { get; set; }
        //public object Author { get; internal set; }
    }
}
