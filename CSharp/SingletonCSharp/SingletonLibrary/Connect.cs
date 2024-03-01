using System;

namespace SingletonLibrary
{
    class Connect
    {
        public Connect()
        {

        }

        public Connect(String host, String database, String username, String password)
        {
            this.Host = host;
            this.Database = database;
            this.Username = username;
            this.Password = password;
        }

        private String _host;
        private String _database;
        private String _username;
        private String _password;

        public string Host
        {
            get
            {
                return _host;
            }

            set
            {
                _host = value;
            }
        }

        public string Database
        {
            get
            {
                return _database;
            }

            set
            {
                _database = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        
    }
}
