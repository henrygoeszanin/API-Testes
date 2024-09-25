using APITestes.Models;

namespace APITestes.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateUser(UserModel userModel);
        Task<IEnumerable<UserModel>> GetAllUsers();


    }
}