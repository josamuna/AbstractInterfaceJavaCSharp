using SingletonLibrary;
using System;

namespace AbstractClassUsage
{
    public abstract class Person
    {

        public Person()
        {

        }

        public Person(int id, String firstName, String lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        private int id;
        private String firstName;
        private String lastName;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        /// <summary>
        /// Print Person's identity without using Database connection.
        /// </summary>
        public abstract void ShowIdentity();

        /// <summary>
        /// Show Person's identity with a connection to the DataBase by using Person ID
        /// </summary>
        /// <param name="id">Person Id</param>
        public abstract void ShowDynamicIdentity(int id);

        /// <summary>
        /// Insert new Person into the database by passing a Person reference (Any type of Person)
        /// </summary>
        /// <param name="p">Person object</param>
        /// <returns></returns>
        public abstract int Add(Person p);
    }
}
