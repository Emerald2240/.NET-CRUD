using System;
using System.Data.SqlClient;

namespace CrudApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            // SqlConnection sqlConnection;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Orji Michael C\source\repos\CrudApp\CrudApp\SampleDatabase.mdf';Integrated Security=True;Connect Timeout=30";

            StarterFunction(connectionString);

           

        }

        public static void CreateOperation(SqlConnection sqlConnection)
        {
            //CREATE
            //Ask user for name and age
            Console.WriteLine("Enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your Age: ");
            int userAge = int.Parse(Console.ReadLine());

            //Make sql query
            string insertQuery = $"INSERT INTO Details(UserName, UserAge) VALUES('{userName}', {userAge})";

            //Run sql query
            SqlCommand insertCommand = new SqlCommand(insertQuery, sqlConnection);
            insertCommand.ExecuteNonQuery();

            //Show info has been added
            Console.WriteLine($"Name: {userName} and Age: { userAge } succesfully added into table.\n\n");
            ReadOperation(sqlConnection);
        }

        public static void ReadOperation(SqlConnection sqlConnection)
        {
            string readQuery = "SELECT * FROM Details";
            SqlCommand readCommand = new SqlCommand(readQuery, sqlConnection);
            SqlDataReader dataReader = readCommand.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine($"Id: {dataReader.GetValue(0)} | Name: {dataReader.GetValue(1)} \t| Age: {dataReader.GetValue(2)}");
            }
            Console.WriteLine("\n\n");
            //Close sql connection
        }

        public static void UpdateOperation(SqlConnection sqlConnection)
        {
            //UPDATE
            //Ask user for ID of row its age is to be edited
            Console.WriteLine("Enter item ID you'd like to update: ");
            int userID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new age: ");
            string userAge = Console.ReadLine();


            //Make sql query
            string updateQuery = $"UPDATE Details " +
                $"SET UserAge = {userAge}" +
                $" WHERE Id = {userID}";

            //Run sql query
            SqlCommand updateCommand = new SqlCommand(updateQuery, sqlConnection);
            updateCommand.ExecuteNonQuery();

            //Show row has been updated
            Console.WriteLine($"ID: {userID} was succesfully updated.\n\n");
            ReadOperation(sqlConnection);
        }

        public static void DeleteOperation(SqlConnection sqlConnection)
        {
            //UPDATE
            //Ask user for ID of row to be deleted
            Console.WriteLine("Enter item ID you'd like to delete: ");
            int userID = int.Parse(Console.ReadLine());


            //Make sql query
            string deleteQuery = $"DELETE FROM Details " +
                $" WHERE Id = {userID}";

            //Run sql query
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
            deleteCommand.ExecuteNonQuery();

            //Show row has been deleted
            Console.WriteLine($"ID: {userID} was succesfully deleted.\n\n");
            ReadOperation(sqlConnection);
        }

        public static void StarterFunction(string connectionString)
        {
            try
            {
                //Connect to database
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();

                Console.WriteLine("Database succesfully connected\n");
                Console.WriteLine("################## Cheat Sheet ################");
                Console.WriteLine("Enter 1 for Create");
                Console.WriteLine("Enter 2 for Read");
                Console.WriteLine("Enter 3 for Update");
                Console.WriteLine("Enter 4 for Delete");
                Console.WriteLine("Enter anything else to close the program\n");

                Console.Write(">>>>>>>: ");
                int choice = int.Parse(Console.ReadLine());
                Console.WriteLine("");

                switch (choice)
                {
                    case 1:
                        CreateOperation(sqlConnection);
                        StarterFunction(connectionString);
                        break;
                    case 2:
                        ReadOperation(sqlConnection);
                        StarterFunction(connectionString);
                        break;
                    case 3:
                        UpdateOperation(sqlConnection);
                        StarterFunction(connectionString);
                        //Console.WriteLine("Update functionality is still in development");
                        break;
                    case 4:
                        DeleteOperation(sqlConnection);
                        //Console.WriteLine("Delete Operation is still in development.\n\n");
                        StarterFunction(connectionString);
                        break;

                    default:                       
                        break;
                }


                sqlConnection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
