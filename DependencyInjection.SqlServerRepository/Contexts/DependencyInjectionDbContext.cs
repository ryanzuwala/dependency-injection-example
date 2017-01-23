using System;
using System.Collections.Generic;
using DependencyInjection.Common.Models;

namespace DependencyInjection.Repositories.SqlServer.Contexts
{
    internal class DependencyInjectionDbContext : IDisposable
    {
        public DependencyInjectionDbContext(string connectionStringOrName)
        {

            // DEMONSTRATION PURPOSES, JUST MIMIC A DATABASE
            this.Books = new List<Book>
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

        public void SaveChanges()
        {
            // commit to the database
        }

        public void Dispose()
        {
            // Dispose of stuff
        }

        public List<Book> Books { get; set; }
    }
}
