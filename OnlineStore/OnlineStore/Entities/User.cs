using Newtonsoft.Json;

namespace OnlineStore.Entities
{
    public class User
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Login { get; private set; }

        public string Password { get; private set; }

        [JsonConstructor]
        public User(string firstName,
            string lastName,
            string login,
            string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            Password = password;
        }

        public User(
             string login,
             string password)
        {
            Login = login;
            Password = password;
        }
    }
}
