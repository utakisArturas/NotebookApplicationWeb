using Microsoft.AspNetCore.Mvc;
using NotebookApplicationWeb.Interfaces;
using NotebookApplicationWeb.Models;

namespace NotebookApplicationWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("CreateNewAccount")]
        public User AddNewUser(string name, string lastName, string email, string password)
        {

            return _userRepository.SignUpNewAccount(name, lastName, email, password);
        }
        [HttpGet("LOGIN")]
        public bool Login(string userName, string password)
        {
            return _userRepository.Login(userName, password);
        }
        [HttpGet("GetUser")]
        public IEnumerable<User> GetUser()
        {
            return _userRepository.GetUser();
        }
    }
}
