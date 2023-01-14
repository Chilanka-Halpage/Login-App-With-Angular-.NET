using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Models
{
    public class UserDBContext: DbContext
    {
        public UserDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
