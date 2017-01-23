using System.Collections.Generic;
using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.Common.Repositories
{
    public interface IRepositoryBase<T>
    {
        T Add(ITransaction transaction, T item);
        T Get(ITransaction transaction, int ID);
        void Delete(ITransaction transaction, int ID);
        void Update(ITransaction transaction, int ID, T item);
        List<T> GetAll(ITransaction transaction);
        List<T> Query(ITransaction transaction, string keywords);

        // FOR DEMONSTRATION PURPOSES ONLY, DO NOT ACTUALLY DO THIS!!!
        string RepositoryInfo { get; }
    }
}
