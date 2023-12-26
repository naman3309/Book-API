using BookAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class BookStoreDB : IdentityDbContext<ApplicationUser>
    {
        public BookStoreDB(DbContextOptions<BookStoreDB> options) : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }

    }

}
