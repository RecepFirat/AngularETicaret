using AngularETicaret.Data.DBModels;
using Microsoft.EntityFrameworkCore;

namespace AngularETicaret.Data.DataContext
{
    public class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
