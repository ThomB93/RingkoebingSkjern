using MySql.Data.MySqlClient;
using RingkoebingSkjern.Models;
using System;

namespace RingkoebingSkjern.DAL
{
    public class DbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DbConnect()
        {
            Initialize(); //set up connection on creation
        }
        //server=mysql4.gear.host;user id=testdb003;database=testdb003;persistsecurityinfo=True
        //Initialize values 
        private void Initialize()
        {
            server = "mysql4.gear.host";
            database = "testdb003";
            uid = "testdb003";
            password = "Pt84-7cau4?I";
            //server=localhost;user id=root;database=pointsdb
            string connectionString = "server=" + server + ";user id=" + uid + ";database=" + database + ";Pwd=" + password;

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection succesful");
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        //Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        //Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                //Console.WriteLine("Connection was closed succesfully");
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //Insert statement
        public string Insert()
        {
            string message = "";
            string query = $"INSERT INTO login VALUES ('frants', '123');";
            //open connection
            if (this.OpenConnection() == true)
            {
                message = "Established connection";
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Insert query succesfully executed.");

                //close connection
                this.CloseConnection();
            }
            return message;
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE STATEMENT";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE STATEMENT";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public Login SelectUser(string brugernavn) //select user based on username
        {
            string query = "SELECT * FROM login WHERE brugernavn='" + brugernavn + "';";

            //Create a list to store the result
            Login login = new Login();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    login.Brugernavn = dataReader.GetString(0);
                    login.Adgangskode = dataReader.GetString(1);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return login;
            }
            else
            {
                return login;
            }
        }
    }
}