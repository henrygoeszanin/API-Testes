using APITestes.Models;
using APITestes.Services;
using Microsoft.EntityFrameworkCore;
using NanoidDotNet;

namespace APITestes.Service.User
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUser(UserModel userModel)
        {
            userModel.UserId = GenerateUniqueId();

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public string GenerateUniqueId()
        {
            return Nanoid.Generate(Nanoid.Alphabets.Default, 12); // Gera um ID de 12 caracteres
        }
    }
}
