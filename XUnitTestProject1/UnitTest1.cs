using System;
using Xunit;
using System.Data.SqlClient;

namespace XUnitTestProject1
{
    public class BasicTests
    {
        [Fact]
        public void BasicTrueOrFalseTest()
        {
            bool naLie = false;
            Assert.True(naLie);
        }

        [Fact]
        public void BasicExceptionTest() 
        {
            int userAge;
            Assert.ThrowsAny<Exception>( () => userAge = int.Parse("3r") );
        }


        [Fact]
        public void SqlConnectionTest()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='C:\Users\Orji Michael C\source\repos\CrudApp\CrudApp\SampleDatabase.mdf';Integrated Security=True;Connect Timeout=30";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

    }
}
