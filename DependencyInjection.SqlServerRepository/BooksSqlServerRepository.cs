using System;
using System.Collections.Generic;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;

namespace DependencyInjection.SqlServerRepository
{
    public class BooksSqlServerRepository : IBooksRepository
    {
        public string RepositoryInfo
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public List<Book> Add(ITransaction transaction, Book item)
        {
            throw new NotImplementedException();
        }

        public List<Book> Delete(ITransaction transaction, int ID)
        {
            throw new NotImplementedException();
        }

        public List<Book> Get(ITransaction transaction, int ID)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllByPublishDateRange(ITransaction transaction, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllByPublisher(ITransaction transaction, string publisherName)
        {
            throw new NotImplementedException();
        }

        public List<Book> Query(ITransaction transaction, string keywords)
        {
            throw new NotImplementedException();
        }

        public List<Book> Update(ITransaction transaction, int ID, Book item)
        {
            throw new NotImplementedException();
        }
    }
}
