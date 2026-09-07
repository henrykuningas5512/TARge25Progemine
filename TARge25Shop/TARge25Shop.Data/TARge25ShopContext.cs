using Microsoft.EntityFrameworkCore;
using TARge25Shop.Core.Domain;

namespace TARge25Shop.Data
{
    //nimetasime classi TARge25ShopContext, mis pärib Dbcontext klassi
    public class TARge25ShopContext : DbContext
    {
        public TARge25ShopContext(DbContextOptions<TARge25ShopContext> options)
            : base(options) { }

        //vajada lisada dbSet, mis on seotud meie domain klassiga Spaceship
        public DbSet<Spaceship> Spaceships { get; set; }
    }
}
