using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.OracleRepository;
using DependencyInjection.OracleRepository.SqlCommands;
using DependencyInjection.Repositories.Oracle.Contexts;

namespace DependencyInjection.Repositories.Oracle
{
    public class OracleBooksRepository : OracleRepositoryBase, IBooksRepository
    {
        // FOR DEMONSTRATION ONLY - DO NOT ACTUALLY MAKE SOMETHING LIKE THIS!
        public string RepositoryInfo
        {
            get
            {
                return "This is Oracle!";
            }
        }

        public Book Add(ITransaction transaction, Book item)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            connection.ExecuteSqlCommand(@"
                INSERT INTO Books (Title, Author, PublishDate, Publisher)
                VALUES (@title, @author, @publish_date, @publisher);",
                    new OracleSqlParameter("@title", DbParameterType.VARCHAR2, item.Title),
                    new OracleSqlParameter("@author", DbParameterType.VARCHAR2, item.Author),
                    new OracleSqlParameter("@publish_date", DbParameterType.DATETIME, item.PublishDate),
                    new OracleSqlParameter("@publisher", DbParameterType.VARCHAR2, item.Publisher)
                );

            return item;
        }

        public List<Book> GetAllByPublisher(ITransaction transaction, string publisherName)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            return connection.ExecuteQuery<Book>(@"
                SELECT *
                FROM Books
                WHERE Publisher = @publisher;",
                    new OracleSqlParameter("@publisher", DbParameterType.VARCHAR2, publisherName)
                );
        }

        public List<Book> Query(ITransaction transaction, string keywords)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            return connection.ExecuteQuery<Book>(@"
                SELECT *
                FROM Books 
                WHERE Publisher LIKE @keywords
                    OR Author LIKE @keywords
                    OR Title LIKE @keywords;
                ",
                    new OracleSqlParameter("@keywords", DbParameterType.VARCHAR2, keywords.ToLower())
                );
        }

        public void Update(ITransaction transaction, int ID, Book item)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            connection.ExecuteSqlCommand(@"
                UPDATE Books
                SET 
                    Publisher = @publisher,
                    Author = @author,
                    Title = @title,
                    PublishDate = @publish_date
                WHERE ID = @id;
                ",
                    new OracleSqlParameter("@id", DbParameterType.INT, ID),
                    new OracleSqlParameter("@title", DbParameterType.VARCHAR2, item.Title),
                    new OracleSqlParameter("@author", DbParameterType.VARCHAR2, item.Author),
                    new OracleSqlParameter("@publish_date", DbParameterType.DATETIME, item.PublishDate),
                    new OracleSqlParameter("@publisher", DbParameterType.VARCHAR2, item.Publisher)
                );
        }

        public void Delete(ITransaction transaction, int ID)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            connection.ExecuteSqlCommand(@"
                DELETE FROM Books
                WHERE ID = @id;
                ",
                    new OracleSqlParameter("@id", DbParameterType.INT, ID)
                );
        }

        public Book Get(ITransaction transaction, int ID)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            List<Book> booksResult = connection.ExecuteQuery<Book>(@"
                SELECT *
                FROM Books
                WHERE ID = @id;
                ",
                    new OracleSqlParameter("@id", DbParameterType.INT, ID)
                );

            return booksResult.Count > 0 ? booksResult[0] : null;
        }

        public List<Book> GetAllByPublishDateRange(ITransaction transaction, DateTime startDate, DateTime endDate)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            return connection.ExecuteQuery<Book>(@"
                SELECT *
                FROM Books 
                WHERE PublishDate >= @startDate
                    AND PublishDate <= @endDate;
                ",
                    new OracleSqlParameter("@startDate", DbParameterType.DATETIME, startDate),
                    new OracleSqlParameter("@endDate", DbParameterType.DATETIME, endDate)
                );
        }

        public List<Book> GetAll(ITransaction transaction)
        {
            OracleSqlConnection connection = base.GetConnection(transaction);

            return connection.ExecuteQuery<Book>("SELECT * FROM Books;");
        }
    }
}
