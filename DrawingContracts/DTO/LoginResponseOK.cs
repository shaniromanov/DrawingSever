

namespace DrawingContracts.DTO
{
    public class LoginResponseOK:LoginResponse
    {
        public LoginResponseOK(string id, string name)
        {
            User = new User();
            User.UserName = name;
            User.EmailAddress = id;
        }
        public User User { get; set; }
    }
}
