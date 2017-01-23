using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.SqlServer.Contexts;

namespace DependencyInjection.Repositories.SqlServer.Transactions
{
    public class SqlServerTransaction : ITransaction
    {
        private DependencyInjectionDbContext _databaseContext;

        internal SqlServerTransaction(string connectionStringOrName)
        {
            this._databaseContext = new DependencyInjectionDbContext(connectionStringOrName);
        }

        private SqlServerTransaction() { }

        public void Commit()
        {
            this._databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            this._databaseContext.Dispose();
        }

        internal DependencyInjectionDbContext DatabaseContext
        {
            get
            {
                return this._databaseContext;
            }
        }
    }
}
