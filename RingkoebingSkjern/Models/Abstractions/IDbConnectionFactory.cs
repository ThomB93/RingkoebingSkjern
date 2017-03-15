using System.Data;

namespace RingkoebingSkjern.Models.Abstractions
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
