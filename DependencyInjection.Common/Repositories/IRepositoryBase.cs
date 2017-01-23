using System.Collections.Generic;
using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.Common.Repositories
{
    public interface IRepositoryBase<T>
    {
        List<T> Add(ITransaction transaction, T item);
        List<T> Get(ITransaction transaction, int ID);
        List<T> Delete(ITransaction transaction, int ID);
        List<T> Update(ITransaction transaction, int ID, T item);
        List<T> Query(ITransaction transaction, string keywords);

        // FOR DEMONSTRATION PURPOSES ONLY, DO NOT ACTUALLY DO THIS!!!
        string RepositoryInfo { get; }
    }
}
