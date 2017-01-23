using System;

namespace DependencyInjection.Common.Repositories.Transactions
{
    public interface ITransaction : IDisposable
    {
        void Commit();
    }
}
