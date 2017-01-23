using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.Oracle.Contexts;

namespace DependencyInjection.Repositories.Oracle.Transactions
{
    public class OracleTransaction : ITransaction
    {
        private readonly OracleSqlConnection _connection;

        internal OracleTransaction(string connectionStringOrName)
        {
            this._connection = new OracleSqlConnection(connectionStringOrName);
        }

        private OracleTransaction() { }

        public void Commit()
        {
            // Commit the Oracle transaction
        }

        public void Dispose()
        {
            
        }

        internal OracleSqlConnection Connection
        {
            get
            {
                return this._connection;
            }
        }
    }
}
