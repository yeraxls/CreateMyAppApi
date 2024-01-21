using DB.Models;

namespace CreateMyApp.Models
{
    public class NewUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static explicit operator User(NewUser user)
        {
            return new User
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
