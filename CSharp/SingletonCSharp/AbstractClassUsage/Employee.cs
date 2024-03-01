using SingletonLibrary;
using System;
using System.Data;

namespace AbstractClassUsage
{
    public class Employee : Person
    {
        public Employee()
        {

        }

        public Employee(int id, String firstName, String lastName, String cnss) : base(id, firstName, lastName)
        {
            this.Cnss = cnss;
        }

        private String _cnss;

        public string Cnss
        {
            get
            {
                return _cnss;
            }

            set
            {
                _cnss = value;
            }
        }

        public override void ShowIdentity()
        {
            Console.WriteLine(String.Format("Employee with ID [{0}], FirstName [{1}], LastName [{2}], Social Security [{3}]", Id, FirstName, LastName, Cnss));
        }

        public override void ShowDynamicIdentity(int id)
        {
            // Open Connection if closed
            if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Closed)
                ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Open();

            using (IDbCommand cmd = ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).CreateCommand())
            {
                cmd.CommandText = "SELECT employee.id, employee.firstname, employee.lastname, employee.cnss FROM employee WHERE employee.id=@id";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, id));

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    Console.WriteLine(String.Format("Employee with ID [{0}], FirstName [{1}], LastName [{2}], Social Security [{3}]", Convert.ToInt32(rd["id"]), rd["firstname"].ToString(), rd["lastname"].ToString(), rd["cnss"].ToString()));
                }

                rd.Dispose();
            }
        }

        public override int Add(Person p)
        {
            int record = 0;

            // Open Connection if closed
            if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Closed)
                ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Open();

            using (IDbCommand cmd = ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).CreateCommand())
            {
                cmd.CommandText = "INSERT INTO employee(id,firstName,lastName,cnss) VALUES(@id,@firstName,@lastName,@cnss)";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, p.Id));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@firstName", 100, DbType.String, p.FirstName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@lastName", 100, DbType.String, p.LastName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@cnss", 100, DbType.String, ((Employee)p).Cnss));

                record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("Failed to insert Person data to the database!");
            }

            return record;
        }
    }

}
