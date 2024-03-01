using AbstractClassUsage;
using SingletonLibrary;
using System;
using System.Data;

namespace TestAbstractClassUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person e1 = new Employee();
                e1.Id = 1;
                e1.FirstName = "Josue";
                e1.LastName = "Isamuna";
                ((Employee)e1).Cnss = "12IJ784GSD890";

                // insert Employee 1 into the database
                e1.Add(e1);
                Console.WriteLine("Employee inserted successfully!");

                Person e2 = new Employee();
                e2.Id = 2;
                e2.FirstName = "Nathan";
                e2.LastName = "Kibambe";
                ((Employee)e2).Cnss = "5239NBK874902";

                // Insert Employee 2 into the Database
                e2.Add(e2);
                Console.WriteLine("Employee inserted successfully!");

                // Students Insertion
                Person s1 = new Student(1, "Martin", "Shabani", "54546MTCFE514");
                s1.Add(s1);
                Console.WriteLine("Student inserted successfully!");

                Person s2 = new Student(2, "Tresor", "Ndeze", "83843765TSREGF");
                s2.Add(s2);

                Console.WriteLine("Student insert successfully!");
                // Show inserted values for Employee
                //			e1.ShowIdentity();
                e1.ShowDynamicIdentity(e1.Id);
                Console.WriteLine("-----------------------------------------");
                //			e2.ShowIdentity();
                e2.ShowDynamicIdentity(e2.Id);
                Console.WriteLine("-----------------------------------------");

                // Show inserted values for Student
                s1.ShowDynamicIdentity(s1.Id);
                Console.WriteLine("------------------------------------------");
                s2.ShowDynamicIdentity(s2.Id);
                Console.WriteLine("-----------------------------------------");

                //Person e1 = new Employee(1, "Josue", "Isamuna", "12IJ784GSD890");
                //e1.ShowIdentity();

                //Person e2 = new Employee(2, "Kavira", "Kataliko", "KV12537490598GH");
                //e2.ShowIdentity();

                //Person e3 = new Employee();
                //e3.Id = 3;
                //e3.FirstName = "Nathan";
                //e3.LastName = "Kibambe";
                //((Employee)e3).Cnss = "239NBK874902";

                //e3.ShowIdentity();
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
