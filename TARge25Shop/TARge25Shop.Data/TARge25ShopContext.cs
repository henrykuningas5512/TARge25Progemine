using Microsoft.EntityFrameworkCore;

namespace TARge25Shop.Data
{
    //nimetasime classi TARge25ShopContext, mis pärib Dbcontext klassi
    public class TARge25ShopContext : DbContext
    {
        public TARge25ShopContext(DbContextOptions<TARge25ShopContext> options)
            : base(options) { }
    }
}
