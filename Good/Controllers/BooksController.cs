using System;
using System.Collections.Generic;
using System.Web.Http;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;

namespace Good.Controllers
{
    public class BooksController : ApiController
    {
        private readonly ITransactionFactory transactionFactory;
        private readonly IBooksRepository booksRepository;

        public BooksController(ITransactionFactory transactionFactory, IBooksRepository booksRepository)
        {
            if(transactionFactory == null)
            {
                throw new ArgumentNullException("transactionFactory is null!!!!");
            }

            if (booksRepository == null)
            {
                throw new ArgumentNullException("booksRepository is null!!!!");
            }

            this.transactionFactory = transactionFactory;
            this.booksRepository = booksRepository;
        }

        public IHttpActionResult Get(string keywords)
        {
            using (ITransaction transaction = this.transactionFactory.Create())
            {
                List<Book> books = this.booksRepository.Query(transaction, keywords);

                return Ok(books);
            }
        }

        public IHttpActionResult Post(Book book)
        {
            using (ITransaction transaction = this.transactionFactory.Create())
            {
                // Add the book
                this.booksRepository.Add(transaction, book);

                // Commit changes to DB
                transaction.Commit();

                return Created(string.Format("/Books/{0}", book.ID), book);
            }
        }

        public IHttpActionResult Get()
        {
            using (ITransaction transaction = this.transactionFactory.Create())
            {
                List<Book> allBooks = this.booksRepository.GetAll(transaction);
                return Ok(allBooks);
            }
        }
    }
}
