using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection.OracleRepository.SqlCommands
{
    internal enum DbParameterType
    {
        VARCHAR,
        VARCHAR2,
        INT,
        DATETIME,
        DATETIME2
    }

    internal struct OracleSqlParameter
    {
        public OracleSqlParameter(string parameterName, DbParameterType parameterType, object parameterValue)
        {
            this.ParameterName = parameterName;
            this.ParameterType = parameterType;
            this.ParameterValue = parameterValue;
        }

        internal string ParameterName { get; private set; }
        internal DbParameterType ParameterType { get; private set; }
        internal object ParameterValue { get; private set; }
    }
}
