using MyMovies.Entities;
using MyMovies.Repositories.Api;
using Sharprompt;

namespace MyMovies.Services
{
    public class LoginService
    {
        private readonly LoginRepository _loginRepository;

        public LoginService(LoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public AuthenticationToken Login()
        {
            AuthenticationToken authenticationToken = null;
            do
            {
                Console.Clear();
                Console.WriteLine("Login\n");

                var authenticate = Prompt.Bind<Authenticate>();
                authenticationToken = _loginRepository.Login(authenticate);
                if (string.IsNullOrEmpty(authenticationToken?.Token))
                {
                    Console.WriteLine(authenticationToken?.Message);
                    Console.ReadKey();
                }

            } while (string.IsNullOrEmpty(authenticationToken?.Token));

            return authenticationToken;
        }
    }
}
