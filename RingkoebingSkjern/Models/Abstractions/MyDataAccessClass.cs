namespace RingkoebingSkjern.Models.Abstractions
{
    public class MyDataAccessClass
    {
        private IDbConnectionFactory connectionFactory;

        public MyDataAccessClass(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public void Insert(string brugernavn, string adgangskode)
        {
            var query = $"INSERT INTO login VALUES ('" + brugernavn + "', '"+ adgangskode + "')";
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();//is not actually necessary as the using statement will make sure to close the connection.
                }
            }
        }
    }
}