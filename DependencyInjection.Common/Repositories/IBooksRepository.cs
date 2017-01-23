using System;
using System.Collections.Generic;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.Common.Repositories
{
    public interface IBooksRepository : IRepositoryBase<Book>
    {
        List<Book> GetAllByPublisher(ITransaction transaction, string publisherName);

        List<Book> GetAllByPublishDateRange(ITransaction transaction, DateTime startDate, DateTime endDate);
    }
}
