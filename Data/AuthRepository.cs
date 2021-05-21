using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<string>> Login(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if(await UserExists(user.email)){
                response.success = false;
                response.messsage = "User already exists!";
                return response;
            }
            CreatePasswordHash(password, out  byte[] passwordHash, out byte[] passwordSalt);
            user.passwordHash = passwordHash;
            user.passwordSalt = passwordSalt;
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            
            response.data = user.id;
            return response;
        }

        public async Task<bool> UserExists(string email)
        {
            if(await _context.users.AnyAsync(c => c.email.ToLower().Equals(email.ToLower()))){
                return true;
            }
            return false;
        }
        private void CreatePasswordHash(string password, out  byte[] passwordHash, out byte[] passwordSalt){
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}