using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.SqlServerRepository.Contexts;

namespace DependencyInjection.SqlServerRepository.Transactions
{
    public class SqlServerTransaction : ITransaction
    {
        private DependencyInjectionDbContext _databaseContext;

        public void Commit()
        {
            this._databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            this._databaseContext.Dispose();
        }

        internal object DatabaseContext
        {
            get
            {
                return this._databaseContext;
            }
        }
    }
}
