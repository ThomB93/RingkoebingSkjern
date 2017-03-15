namespace RingkoebingSkjern.Models
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public Login GetLogin(string brugernavn)
        {
            return _loginRepository.GetLogin(brugernavn);
        }
    }
}