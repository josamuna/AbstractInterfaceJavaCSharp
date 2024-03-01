using System;
using System.Data;

namespace SingletonLibrary
{
    interface IConnection
    {
        IDbConnection getConnection();
    }
}
