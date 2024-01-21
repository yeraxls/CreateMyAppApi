using DB.Models;

namespace CreateMyApp.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LeavingDate { get; set; }


        public static explicit operator User(UserDTO user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
