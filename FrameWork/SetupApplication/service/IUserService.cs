using SetupApplication.models;

namespace SetupApplication.service
{
    public interface IUserService
    {
        public  Task<List<UserModel>> GetUserList();
        public  Task <UserModel> GetUser(Guid Id);
        public  Task<UserModel> CreateUser (UserModel user);
    }
}
