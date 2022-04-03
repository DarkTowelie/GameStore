using GameStore.Model;
using System.Data.Entity;

namespace GameStore.ModelContext
{
    class DBContext : DbContext
    {
        public DBContext()
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }
    }
}
