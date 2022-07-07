using NotebookApplicationWeb.Data;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;
using System.Security.Cryptography;

namespace NotebookApplicationWeb.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        }

        public IEnumerable<User> GetUser()
        {
            return _context.Users;
        }

        public User CreateAccount(string userName, string lastName, string email, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User();
            user.Name = userName;
            user.Email = email;
            user.LastName = lastName;
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            return user;
        }

        public User SignUpNewAccount(string name, string lastName, string email, string password)
        {
            var account = CreateAccount(name, lastName, email, password);
            _context.Users.Add(account);
            _context.SaveChanges();
            return account;
        }

        public bool Login(string userName, string password)
        {
            var account = _context.Users.FirstOrDefault(x => x.Name == userName);
            if (VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
                return true;
            return false;
        }
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
