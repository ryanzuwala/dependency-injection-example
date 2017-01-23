using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.Repositories.SqlServer.Transactions
{
    public class SqlServerTransactionFactory : ITransactionFactory
    {
        private readonly string _connectionStringOrName;

        public SqlServerTransactionFactory(string connectionStringOrName)
        {
            this._connectionStringOrName = connectionStringOrName;
        }

        public ITransaction Create()
        {
            return new SqlServerTransaction(this._connectionStringOrName);
        }
    }
}
