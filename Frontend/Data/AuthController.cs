using Backend.Auth;

namespace Frontend.Data
{
    public class AuthController
    {
        private readonly AuthManager _authManager;
        private Credentials? currentUserCredentials;

        public Credentials CurrentUserCredentials { get => currentUserCredentials ?? throw new NullReferenceException(); private set => currentUserCredentials = value; }

        public AuthController() {
            _authManager = new AuthManager();
        }

        public void SignIn(string username, string password) => CurrentUserCredentials = _authManager.SignIn(username, password);

        public void SignUp(string username, string password) => _authManager.SignUp(username, password);

        public void SignOut() => currentUserCredentials = null;

        public bool IsSignedIn { get => currentUserCredentials != null; }

    }
}
