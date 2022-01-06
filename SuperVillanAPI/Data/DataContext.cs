using Microsoft.EntityFrameworkCore;

namespace SuperVillanAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<SuperVillan> SuperVillans {get; set; }

    }
}

