using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.Repositories.Oracle.Transactions
{
    public class OracleTransactionFactory : ITransactionFactory
    {
        private readonly string _connectionStringOrName;

        public OracleTransactionFactory(string connectionStringOrName)
        {
            this._connectionStringOrName = connectionStringOrName;
        }

        public ITransaction Create()
        {
            return new OracleTransaction(this._connectionStringOrName);
        }
    }
}
