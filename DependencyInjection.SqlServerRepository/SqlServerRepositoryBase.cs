using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.SqlServerRepository.Transactions;

namespace DependencyInjection.SqlServerRepository
{
    internal abstract class SqlServerRepositoryBase
    {
        internal object GetContext(ITransaction transaction)
        {
            SqlServerTransaction sqlTransaction = (SqlServerTransaction)transaction;
            return sqlTransaction.DatabaseContext;
        }
    }
}
