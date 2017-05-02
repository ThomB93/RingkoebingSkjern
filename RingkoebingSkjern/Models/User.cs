using System.ComponentModel.DataAnnotations;
using RingkoebingSkjern.DAL;

namespace RingkoebingSkjern.Models
{
    public class User
    {
        [Required]
        [Display(Name = "Brugernavn")]
        public string Brugernavn { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Husk mig på denne computer")]
        public bool RememberMe { get; set; }

        [Required]
        [Display(Name = "Rolle")]
        public string Rolle { get; set; }

        /// Checks if user with given password exists in the database
        /// <returns>True if user exist and password is correct</returns>
        public bool IsValid(string _username, string _password)
        {
            DbConnect dbc = new DbConnect();
            return dbc.LoginIsValid(_username, _password);
        }
        public bool OpretNyBruger(string _username, string _password, string _rolle)
        {
            DbConnect dbc = new DbConnect();
            return dbc.OpretNyBruger(_username, _password, _rolle);
        }
    }
}