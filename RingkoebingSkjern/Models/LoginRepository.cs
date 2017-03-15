using RingkoebingSkjern.DAL;
using System.Collections.Generic;

namespace RingkoebingSkjern.Models
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IList<Login> _loginList;
        public Login GetLogin(string brugernavn)
        {
            DbConnect dbConnect = new DbConnect();
            Login login = dbConnect.SelectUser(brugernavn);
            return login;
        }
    }
}