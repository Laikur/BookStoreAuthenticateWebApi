using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newWebApi.Model;

namespace newWebApi.Data
{
    public class BookStoreContext :IdentityDbContext<ApplicationModel>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            :base(options)
        { 
        }

        public DbSet<Books> Booka { get; set; }


    }
}
