using InterfaceUsage;
using SingletonLibrary;
using System;
using System.Data;

namespace TestInterfaceUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IPerson e3 = new Employee();
                ((Employee)e3).Id = 3;
                ((Employee)e3).FirstName = "Rebecca";
                ((Employee)e3).LastName = "Kabene";
                ((Employee)e3).Cnss = "6738RBHJ989363";

                // insert Employee 3 into the database
                e3.Add();
                Console.WriteLine("Employee inserted successfully!");

                IPerson e4 = new Employee();
                ((Employee)e4).Id = 4;
                ((Employee)e4).FirstName = "Sage";
                ((Employee)e4).LastName = "Alingisugho";
                ((Employee)e4).Cnss = "512389ASGYIUE9374";

                // Insert Employee 4 into the Database
                e4.Add();
                Console.WriteLine("Employee inserted successfully!");

                // Students Insertion
                IPerson s3 = new Student(3, "Martin", "Shabani", "54546MTCFE514");
                s3.Add();
                Console.WriteLine("Student inserted successfully!");

                IPerson s4 = new Student(4, "Tresor", "Ndeze", "83843765TSREGF");
                s4.Add();

                Console.WriteLine("Student insert successfully!");
                // Show inserted values for Employee
                //			e3.ShowIdentity();
                e3.ShowDynamicIdentity(((Employee)e3).Id);
                Console.WriteLine("-----------------------------------------");
                //			e4.ShowIdentity();
                e4.ShowDynamicIdentity(((Employee)e4).Id);
                Console.WriteLine("-----------------------------------------");

                // Show inserted values for Student
                s3.ShowDynamicIdentity(((Student)s3).Id);
                Console.WriteLine("------------------------------------------");
                s4.ShowDynamicIdentity(((Student)s4).Id);
                Console.WriteLine("-----------------------------------------");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to insert records to the Database, " + ex.Message);
            }
            finally
            {
                if (ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION) != null)
                {
                    if (ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.MYSQL_CONNECTION).Close();
                }

                if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION) != null)
                {
                    if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Open)
                        ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Close();
                }
            }
            Console.ReadLine();
        }
    }
}
