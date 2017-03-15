using MySql.Data.MySqlClient;
using System.Data;

namespace RingkoebingSkjern.Models.Abstractions
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection("server=mysql4.gear.host;user id=testdb003;database=testdb003;Pwd=Pt84-7cau4?I;");
        }
    }
}