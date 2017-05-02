using MySql.Data.MySqlClient;
using RingkoebingSkjern.Models;
using System;
using System.Collections.Generic;

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
        /*public string InsertUser(string brugernavn, string password)
        {
            string message = "";
            string query = $"INSERT INTO login VALUES ('"+ brugernavn + "', '" + password + "');";
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
        }*/
        public void InsertFrivillig(string fornavn, string efternavn, string telefon,
            string adresse, string email, int postnr)
        {
            string query = $"INSERT INTO frivillig (`fornavn`,`efternavn`,`telefon`,`email`,`adresse`,`post_nr`) VALUES" +
                "('"+ fornavn + "','" + efternavn + "','" + telefon + "','" + email + "','" + adresse + "'," + postnr + ");";
            //open connection
            if (this.OpenConnection() == true)
            {      
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Insert query succesfully executed.");

                //close connection
                this.CloseConnection();
            }
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
        public List<Laug> SelectAllLaug()
        {
            string query = "SELECT * FROM Laug;";

            //Create a list to store the result
            List<Laug> laugListe = new List<Laug>();

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
                    laugListe.Add(new Laug {
                        Id = Int32.Parse(dataReader.GetString(0)),
                        Navn = dataReader.GetString(1),
                        TotalTimer = Int32.Parse(dataReader.GetString(2))
                    });
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return laugListe;
            }
            else
                return laugListe;
        }
        public bool LoginIsValid(string brugernavn, string password) //return true hvis brugernavn + password findes i DB
        {
            string query = "SELECT * FROM login WHERE brugernavn='" + brugernavn + "' AND Password = '" + password + "';";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Dispose();
                    cmd.Dispose();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    dataReader.Dispose();
                    cmd.Dispose();
                    this.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool BrugernavnEksisterer(string brugernavn) //return true hvis brugernavn eksisterer i DB
        {
            string query = "SELECT * FROM login WHERE brugernavn='" + brugernavn + "';";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Dispose();
                    cmd.Dispose();
                    this.CloseConnection();
                    return true;
                }
                else
                {
                    dataReader.Dispose();
                    cmd.Dispose();
                    this.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool OpretNyBruger(string brugernavn, string password, string rolle)
        {
            DbConnect dbc = new DbConnect();
            if(!dbc.BrugernavnEksisterer(brugernavn) && (rolle == "Fri" || rolle == "fri"
                || rolle == "Tov" || rolle == "tov"))//hvis bruger ikke eksisterer i DB og rolle er korrekt
            {
                string query = $"INSERT INTO login (`Brugernavn`, `Password`, `Rolle`) VALUES" +
                "('" + brugernavn + "', '" + password + "','" + rolle + "');";
                //open connection
                if (this.OpenConnection() == true)
                { 
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    //Execute command
                    int affected = cmd.ExecuteNonQuery();
                    if (affected != 0)
                    {
                        this.CloseConnection();
                        return true;
                    }
                    else
                    {
                        this.CloseConnection();
                        return false;
                    }
                }
                else
                {
                    this.CloseConnection();
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }
        public void InsertTidsRegistrering(int frivilligId, int laugId, string startTid)
        {
            string query = $"INSERT INTO frivillig_laug (`frivillig_id`, `laug_id`, `startTid`) VALUES" +
                "(" + frivilligId + ", " + laugId + ",'" + startTid + "');";
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();
                //Console.WriteLine("Insert query succesfully executed.");

                //close connection
                this.CloseConnection();
            }
        }
        //Insert tovholder
        //
    }
}