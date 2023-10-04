namespace Backend.Auth
{
    public class AuthManager
    {
        private readonly List<User> users;
        public AuthManager()
        {
            users = new List<User>();
        }

        public bool ExistsUser(string username) => users.Any(u => u.Username == username);

        public Credentials SignIn(string username, string password)
        {
            if (!users.Any(u => u.Username == username))
            {
                throw new ArgumentException("Invalid username/password");
            }
            var user = users.First(u => u.Username == username);
            if (!user.IsPasswordCorrect(password))
            {
                throw new ArgumentException("Invalid username/password");
            }
            return new Credentials(user.username);
        }

        public void SignUp(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                throw new ArgumentException("Username already exists");
            }
            var user = new User(username, password);
            users.Add(user);
        }
    }
}