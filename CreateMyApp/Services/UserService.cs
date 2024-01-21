using CreateMyApp.Models;
using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CreateMyApp.Services
{
    public class UserService : IUserService
    {
        private readonly MyAppContext _context;
        private readonly IConfiguration _config;
        public UserService(MyAppContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task Register(NewUser newUser)
        {
            await _context.Insert((User)newUser);
            await _context.SaveAll();
            var user = newUser;
        }
        public async Task<User> Authenticate(LoginModel userLogin)
        {
            var currentUser = await _context.Queryable<User>(u => u.Email == userLogin.EMail
                   && u.Password == userLogin.Password).FirstOrDefaultAsync();

            if (currentUser == null)
                return null;

            return currentUser;
        }

        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Crear los claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.Password),
                new Claim(ClaimTypes.Surname, user.LastName)
            };
            // Crear el token

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> SearchUser(UserDTO user)
        {
            var currentUser = await _context.Queryable<User>(u => u.Id == user.Id).FirstOrDefaultAsync();

            if (currentUser == null)
                return null;

            return currentUser;
        }

        public async Task UpdateUser(UserDTO user, User userDB)
        {
            changeModel(user, userDB);
            await _context.SaveAll();
        }

        private void changeModel(UserDTO user, User userDB)
        {
            userDB.Name = user.Name;
            userDB.Email = user.Email;
            userDB.Password = user.Password;
            userDB.LastName = user.LastName;
            userDB.LeavingDate = user.LeavingDate;
        }
    }
}
