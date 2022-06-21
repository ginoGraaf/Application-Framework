using SetupApplication.models;
using SetupApplication.DataBase;
using Microsoft.EntityFrameworkCore;

namespace SetupApplication.service
{
    public class UserService : IUserService
    {
        UserDataContext _userDataContext;
        public UserService(UserDataContext context)
        {
            _userDataContext = context;
        }

        public async Task<UserModel> CreateUser(UserModel user)
        {
            try
            {
                UserModel userCreate = new UserModel { Email = user.Email, Name = user.Name, Passowrd = user.Passowrd };
                _userDataContext.Add(userCreate);
                await _userDataContext.SaveChangesAsync();
                return userCreate;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<UserModel> GetUser(Guid Id)
        {
            var user = await _userDataContext.userModel.FindAsync(Id);
            // UserModel user =
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<UserModel>> GetUserList()
        {
            return await _userDataContext.userModel.ToListAsync();
        }
    }
}
