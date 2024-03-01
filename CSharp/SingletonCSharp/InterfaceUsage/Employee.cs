using SingletonLibrary;
using System;
using System.Data;

namespace InterfaceUsage
{
    public class Employee : IPerson
    {
        public Employee()
        {

        }

        public Employee(int id, String firstName, String lastName, String cnss)
        {
            this._id = id;
            this._firstName = firstName;
            this._lastName = lastName;
            this.Cnss = cnss;
        }

        private int _id;
        private String _firstName;
        private String _lastName;
        private String _cnss;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

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

        public void ShowIdentity()
        {
            Console.WriteLine(String.Format("Employee with ID [{0}], FirstName [{1}], LastName [{2}], Social Security [{3}]", Id, FirstName, LastName, Cnss));
        }

        public void ShowDynamicIdentity(int id)
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

        public int Add()
        {
            int record = 0;

            // Open Connection if closed
            if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Closed)
                ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Open();

            using (IDbCommand cmd = ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).CreateCommand())
            {
                cmd.CommandText = "INSERT INTO employee(id,firstName,lastName,cnss) VALUES(@id,@firstName,@lastName,@cnss)";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, _id));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@firstName", 100, DbType.String, _firstName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@lastName", 100, DbType.String, _lastName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@cnss", 100, DbType.String, _cnss));

                record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("Failed to insert Person data to the database!");
            }

            return record;
        }
    }

}
