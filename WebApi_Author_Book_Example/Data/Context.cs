using Microsoft.EntityFrameworkCore;
using WebApi_Author_Book_Example.Model;

namespace WebApi_Author_Book_Example.Data
{
    public class Context:DbContext
    {
        public DbSet<Author>Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<AuthorDetails> AuthorDetailss { get; set; }

        public Context(DbContextOptions<Context> options):base(options) 
        {
            
        }
    }
}
