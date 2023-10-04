using Backend.Auth;

namespace Backend
{
    public class User
    {
        public string username = string.Empty;
        public string password = string.Empty;

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username
        {
            get => username; private set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Username cannot be empty");
                }
                username = value;
            }
        }
        private string Password
        {
            get => password; set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Password cannot be empty");
                }
                password = value;
            }
        }

        public bool IsPasswordCorrect(string password) => password == this.Password;

        public bool AreCredentialsValid(Credentials creds) => Username == creds.Username;
    }
}