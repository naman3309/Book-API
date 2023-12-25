using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class BookStoreDB : DbContext
    {
        public BookStoreDB(DbContextOptions<BookStoreDB> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

    }

}
