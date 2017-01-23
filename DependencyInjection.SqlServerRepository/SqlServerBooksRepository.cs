using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.SqlServer.Contexts;
using DependencyInjection.Repositories.SqlServer.Transactions;
using DependencyInjection.SqlServerRepository;

namespace DependencyInjection.Repositories.SqlServer
{
    public class SqlServerBooksRepository : SqlServerRepositoryBase, IBooksRepository
    {
        // FOR DEMONSTRATION ONLY - DO NOT ACTUALLY MAKE SOMETHING LIKE THIS!
        public string RepositoryInfo
        {
            get
            {
                return "This is SQL Server!";
            }
        }

        public Book Add(ITransaction transaction, Book item)
        {
            DependencyInjectionDbContext context = base.GetContext(transaction);

            context.Books.Add(item);
            return item;
        }

        public List<Book> GetAllByPublisher(ITransaction transaction, string publisherName)
        {
            DependencyInjectionDbContext context = base.GetContext(transaction);

            return context.Books
                .Where(b =>
                        b.Publisher == publisherName
                )
                .ToList();
        }

        public List<Book> Query(ITransaction transaction, string keywords)
        {
            DependencyInjectionDbContext context = base.GetContext(transaction);
            string lowerCaseKeywords = keywords.ToLower();

            return context.Books
                .Where(b => 
                        b.Title.ToLower().Contains(lowerCaseKeywords)
                    ||  b.Author.ToLower().Contains(lowerCaseKeywords)
                    ||  b.Publisher.ToLower().Contains(lowerCaseKeywords)
                )
                .ToList();
        }

        public void Update(ITransaction transaction, int ID, Book item)
        {
            DependencyInjectionDbContext context = base.GetContext(transaction);

            Book bookToUpdate = context.Books.FirstOrDefault(b => b.ID == ID);

            if(bookToUpdate != null)
            {
                bookToUpdate.Publisher = item.Publisher;
                bookToUpdate.Title = item.Title;
                bookToUpdate.YearPublished = item.YearPublished;
                bookToUpdate.Author = item.Author;
            }
        }

        public void Delete(ITransaction transaction, int ID)
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
    }
}
