using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Common.Models;

namespace Bad.Repositories.SqlServer
{
    public class SqlServerBooksRepository
    {
        // FOR DEMONSTRATION ONLY - DO NOT ACTUALLY MAKE SOMETHING LIKE THIS!
        public string RepositoryInfo
        {
            get
            {
                return "Bad API - This is SQL Server!";
            }
        }

        private List<Book> _booksTable;

        public SqlServerBooksRepository(string connectionStringOrName)
        {
            this._booksTable = new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Author = "Ryan Zuwala",
                    Publisher = "BizStream",
                    Title = "A good book",
                    PublishDate = DateTime.Now
                },
                new Book
                {
                    ID = 2,
                    Author = "Some Guy",
                    Publisher = "Who Knows",
                    Title = "Who Cares",
                    PublishDate = DateTime.Now
                }
            };
        }

        public Book Add(Book item)
        {
            this._booksTable.Add(item);
            return item;
        }

        public List<Book> GetAllByPublisher(string publisherName)
        {
            return this._booksTable.Where(b => b.Publisher == publisherName).ToList();
        }

        public List<Book> Query(string keywords)
        {
            string lowerCaseKeywords = keywords.ToLower();

            return this._booksTable
                .Where(b => 
                        b.Title.ToLower().Contains(lowerCaseKeywords)
                    ||  b.Author.ToLower().Contains(lowerCaseKeywords)
                    ||  b.Publisher.ToLower().Contains(lowerCaseKeywords)
                )
                .ToList();
        }

        public void Update(int ID, Book item)
        {
            Book bookToUpdate = this._booksTable.FirstOrDefault(b => b.ID == ID);

            if(bookToUpdate != null)
            {
                bookToUpdate.Publisher = item.Publisher;
                bookToUpdate.Title = item.Title;
                bookToUpdate.PublishDate = item.PublishDate;
                bookToUpdate.Author = item.Author;
            }
        }

        public void Delete(int ID)
        {
            Book bookToDelete = this._booksTable.FirstOrDefault(b => b.ID == ID);
            if(bookToDelete != null)
            {
                this._booksTable.Remove(bookToDelete);
            }
        }

        public Book Get(int ID)
        { 
            return this._booksTable.FirstOrDefault(b => b.ID == ID);
        }

        public List<Book> GetAllByPublishDateRange(DateTime startDate, DateTime endDate)
        {
            return this._booksTable
                .Where(b =>
                        b.PublishDate >= startDate
                     && b.PublishDate <= endDate
                )
                .ToList();
        }

        public List<Book> GetAll()
        {
            return this._booksTable;
        }
    }
}
