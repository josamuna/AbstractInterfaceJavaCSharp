using SingletonLibrary;
using System;
using System.Data;

namespace AbstractClassUsage
{
    public class Student : Person
    {
        public Student()
        {

        }

        public Student(int id, String firstName, String lastName, String rollNumber) : base(id, firstName, lastName)
        {
            this.RollNumber = rollNumber;
        }

        private String _rollNumber;

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

        public override void ShowIdentity()
        {
            Console.WriteLine(String.Format("Student with ID [{0}], FirstName [{1}], LastName [{2}], Roll Number [{3}]", Id, FirstName, LastName, _rollNumber));
        }

        public override void ShowDynamicIdentity(int id)
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

        public override int Add(Person p)
        {
            int record = 0;

            // Open Connection if closed
            if (ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).State == ConnectionState.Closed)
                ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).Open();

            using (IDbCommand cmd = ConnectionFactory.getConnection(ConnectionType.SQL_SERVER_CONNECTION).CreateCommand())
            {
                cmd.CommandText = "INSERT INTO student(id,firstName,lastName,rollNumber) VALUES(@id,@firstName,@lastName,@rollNumber)";
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@id", 4, DbType.Int32, p.Id));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@firstName", 100, DbType.String, p.FirstName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@lastName", 100, DbType.String, p.LastName));
                cmd.Parameters.Add(UtilitiesFactory.Instance.AddParameter(cmd, "@rollNumber", 100, DbType.String, ((Student)p)._rollNumber));

                record = cmd.ExecuteNonQuery();

                if (record == 0)
                    throw new InvalidOperationException("Failed to insert Person data to the database!");
            }

            return record;
        }
    }
}
