using System;
using System.Collections.Generic;
using System.Linq;
using DependencyInjection.Common.Models;
using DependencyInjection.OracleRepository.SqlCommands;

namespace DependencyInjection.Repositories.Oracle.Contexts
{
    internal class OracleSqlConnection : IDisposable
    {
        // DEMONSTRATION PURPOSES, JUST MIMIC A DATABASE TABLE
        private List<Book> _pretendBooksTable;

        public OracleSqlConnection(string connectionStringOrName)
        {
            this._pretendBooksTable = new List<Book>
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
                    Publisher = "ORACLE!!!",
                    Title = "Who Cares",
                    PublishDate = DateTime.Now
                },
                new Book
                {
                    ID = 3,
                    Author = "Ryan Zuwala",
                    Publisher = "BizStream",
                    Title = "A good book",
                    PublishDate = DateTime.Now
                },
                new Book
                {
                    ID = 4,
                    Author = "Some Guy",
                    Publisher = "Who Knows",
                    Title = "Who Cares",
                    PublishDate = DateTime.Now
                },
                new Book
                {
                    ID = 5,
                    Author = "Ryan Zuwala",
                    Publisher = "BizStream",
                    Title = "A good book",
                    PublishDate = DateTime.Now
                },
                new Book
                {
                    ID = 6,
                    Author = "Some Guy",
                    Publisher = "Who Knows",
                    Title = "Who Cares",
                    PublishDate = DateTime.Now
                },
            };
        }

        public int ExecuteSqlCommand(string sql, params OracleSqlParameter[] parameters)
        {
            // return fake row count
            return 23;
        }

        public List<Book> ExecuteQuery<T>(string sql, params OracleSqlParameter[] parameters)
        {
            if (parameters.Length > 0)
            {
                string lowerCaseKeywords = parameters[0].ParameterValue.ToString().ToLower();

                return this._pretendBooksTable
                    .Where(b =>
                            b.Title.ToLower().Contains(lowerCaseKeywords)
                        || b.Author.ToLower().Contains(lowerCaseKeywords)
                        || b.Publisher.ToLower().Contains(lowerCaseKeywords)
                    )
                    .ToList();
            }
            else
            {
                return this._pretendBooksTable;
            }
        }

        public void SaveChanges()
        {
            // commit to the database
            this.ExecuteSqlCommand("COMMIT;");
        }

        public void Dispose()
        {
            // Dispose of stuff
        }
    }
}
