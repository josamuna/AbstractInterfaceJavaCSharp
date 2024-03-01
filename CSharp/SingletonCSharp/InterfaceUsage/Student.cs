using SingletonLibrary;
using System;
using System.Data;

namespace InterfaceUsage
{
    public class Student : IPerson
    {
        public Student()
        {

        }

        public Student(int id, String firstName, String lastName, String rollNumber)
        {
            this._id = id;
            this._firstName = firstName;
            this.LastName = lastName;
            this.RollNumber = rollNumber;
        }

        private int _id;
        private String _firstName;
        private String _lastName;
        private String _rollNumber;

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

        public string RollNumber
        {
            get
            {
                return _rollNumber;
            }

            set
            {
                _rollNumber = value;
            }
        }

        public void ShowIdentity()
        {
            Console.WriteLine(String.Format("Student with ID [{0}], FirstName [{1}], LastName [{2}], Roll Number [{3}]", Id, FirstName, LastName, RollNumber));
        }

        public void ShowDynamicIdentity(int id)
        {
            // Open Connection if closed
            if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Closed)
                ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Open();

            using (IDbCommand cmd = ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).CreateCommand())
            {
                cmd.CommandText = "SELECT student.id, student.firstName, student.lastName, student.rollNumber FROM student WHERE student.id=@id";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, id));

                IDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    Console.WriteLine(String.Format("Student with ID [{0}], FirstName [{1}], LastName [{2}], Roll Number [{3}]", Convert.ToInt32(rd["id"]), rd["firstname"].ToString(), rd["lastname"].ToString(), rd["rollNumber"].ToString()));
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
                cmd.CommandText = "INSERT INTO student(id,firstName,lastName,rollNumber) VALUES(@id,@firstName,@lastName,@rollNumber)";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, _id));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@firstName", 100, DbType.String, _firstName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@lastName", 100, DbType.String, _lastName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@rollNumber", 100, DbType.String, _rollNumber));

                record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("Failed to insert Person data to the database!");
            }

            return record;
        }
    }
}
