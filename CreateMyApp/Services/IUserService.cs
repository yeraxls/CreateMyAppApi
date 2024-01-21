using CreateMyApp.Models;
using DB.Models;

namespace CreateMyApp.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(LoginModel userLogin);
        string Generate(User user);
        Task Register(NewUser newUser);
        Task<User> SearchUser(UserDTO user);
        Task UpdateUser(UserDTO user, User userDB);
    }
}