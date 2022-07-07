using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Interfaces
{
    public interface IUserRepository
    {
        public User SignUpNewAccount(string name, string lastName, string email, string password);
        public User CreateAccount(string userName, string lastName, string email, string password);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool Login(string userName, string password);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public IEnumerable<User> GetUser();
    }
}
