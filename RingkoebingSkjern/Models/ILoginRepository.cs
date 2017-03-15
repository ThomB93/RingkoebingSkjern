namespace RingkoebingSkjern.Models
{
    public interface ILoginRepository
    {
        Login GetLogin(string brugernavn);
    }
}
