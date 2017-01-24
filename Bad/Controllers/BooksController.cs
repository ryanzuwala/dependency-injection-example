using System.Collections.Generic;
using System.Configuration;
using System.Web.Http;
using Bad.Repositories.SqlServer;
using DependencyInjection.Common.Models;

namespace Bad.Controllers
{
    public class BooksController : ApiController
    {
        private readonly SqlServerBooksRepository booksRepository;

        public BooksController()
        {
            this.booksRepository = new SqlServerBooksRepository(ConfigurationManager.ConnectionStrings["books_mssql_database"].ConnectionString);
        }

        public List<Book> Get(string keywords)
        {
            List<Book> books = this.booksRepository.Query(keywords);
            return books;
        }

        public Book Post(Book book)
        {
            // Add the book
            this.booksRepository.Add(book);

            return book;
        }

        public IHttpActionResult Get()
        {

            List<Book> allBooks = this.booksRepository.GetAll();
            return Ok(allBooks);
        }
    }
}
