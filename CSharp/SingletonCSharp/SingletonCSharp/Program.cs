using SingletonLibrary;
using System;
using System.Data;

namespace SingletonCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection con = null;
            try
            {
                // Test MySQL Connection
                con = ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION);
                Console.WriteLine(String.Format("{0} {1} With Connection string: {2}", "Successfully connected to the database", con.Database, con.ToString()));

                // Test SQLServer Connection
                Console.WriteLine(String.Format("{0} {1} With Connection string: {2}", "Successfully connected to the database", con.Database, con.ToString()));
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION) != null)
                {
                    if(ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).Close();
                }

                if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION) != null)
                {
                    if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Close();
                }
            }
        }
    }
}
