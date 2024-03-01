using System;
using System.Data;

namespace SingletonLibrary
{
    public class UtilitiesFactory
    {
        private UtilitiesFactory()
        {

        }

        private static UtilitiesFactory _instance;

        public static UtilitiesFactory Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UtilitiesFactory();
                }
                return _instance;
            }
        }

        public IDbDataParameter AddParameter(IDbCommand command, String parameterName, int size, DbType dbDataType, object parameterValue)
        {
            IDbDataParameter param = command.CreateParameter();
            param.ParameterName = parameterName;
            param.Size = size;
            param.DbType = dbDataType;
            param.Value = parameterValue;

            return param;
        }
    }
}
