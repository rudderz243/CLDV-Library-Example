using Microsoft.EntityFrameworkCore;

namespace LibraryManagerEF
{
    // we created a class that exactly matches the table in the database
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public double ReplacementPrice { get; set; }
        public int CategoryID { get; set; }
    }

    // then create a DbContext class, in order to use EF to interact with out data
    // we inherit from DbContext, the main class of EF
    public class AppDbContext : DbContext
    {
        // we create a "set" of all the data in the book table, and make it accessible 
        public DbSet<Book> Books { get; set; }
        // we then override a default method, in order to pass through our connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=lab7L95SR\\SQLEXPRESS; Initial Catalog=LibraryDB; Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}
