using Microsoft.EntityFrameworkCore;
using SetupApplication.models;

namespace SetupApplication.DataBase
{
    public class UserDataContext: DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext>options):base(options)
        {

        }
        public DbSet<UserModel> userModel { get; set; }
    }
}
