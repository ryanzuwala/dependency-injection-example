using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.Oracle.Contexts;
using DependencyInjection.Repositories.Oracle.Transactions;

namespace DependencyInjection.OracleRepository
{
    public abstract class OracleRepositoryBase
    {
        internal OracleSqlConnection GetConnection(ITransaction transaction)
        {
            OracleTransaction oracleTransaction = (OracleTransaction)transaction;
            return oracleTransaction.Connection;
        }
    }
}
