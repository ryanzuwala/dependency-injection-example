using System;
using System.Collections.Generic;
using DependencyInjection.Common.Models;

namespace DependencyInjection.SqlServerRepository.Contexts
{
    internal class DependencyInjectionDbContext : IDisposable
    {
        public DependencyInjectionDbContext(string connectionStringOrName)
        {

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
