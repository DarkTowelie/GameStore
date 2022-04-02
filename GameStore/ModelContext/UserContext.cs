using GameStore.Model;
using System.Data.Entity;

namespace GameStore.ModelContext
{
    class UserContext : DbContext
    {
        public UserContext()
        {
            
        }

        public DbSet<User> User { get; set; }
    }
}
