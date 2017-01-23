using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.SqlServer.Contexts;
using DependencyInjection.Repositories.SqlServer.Transactions;

namespace DependencyInjection.SqlServerRepository
{
    public abstract class SqlServerRepositoryBase
    {
        internal DependencyInjectionDbContext GetContext(ITransaction transaction)
        {
            SqlServerTransaction sqlTransaction = (SqlServerTransaction)transaction;
            return sqlTransaction.DatabaseContext;
        }
    }
}
