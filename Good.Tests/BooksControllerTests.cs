using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using DependencyInjection.Common.Models;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using Good.Controllers;
using Moq;
using NUnit.Framework;

namespace Good.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private Mock<IBooksRepository> booksRepositoryMock;
        private Mock<ITransactionFactory> transactionFactoryMock;

        private List<Book> testData = new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Title = "Unit Testing",
                    PublishDate = DateTime.Now,
                    Author = "Ryan #1",
                    Publisher = "Bizstream"
                }
            };

        [SetUp]
        public void Initialize()
        {
            this.booksRepositoryMock = new Mock<IBooksRepository>();
            this.transactionFactoryMock = new Mock<ITransactionFactory>();

            // return mock transactions when .Create() is called on a TX factory in controller
            this.transactionFactoryMock.Setup(x => x.Create()).Returns(new Mock<ITransaction>().Object);

            // fake test data for books repository mock
            this.booksRepositoryMock.Setup(x => x.GetAll(It.IsAny<ITransaction>())).Returns(testData);
            this.booksRepositoryMock.Setup(x => x.Query(It.IsAny<ITransaction>(), It.IsAny<string>())).Returns(testData);
        }



        [Test]
        [Category("GoodAPI Books Tests")]
        public void GetKeywords_Test()
        {
            // arrange            
            BooksController booksController = new BooksController(transactionFactoryMock.Object, booksRepositoryMock.Object);
            booksController.Request = new HttpRequestMessage();
            booksController.Configuration = new HttpConfiguration();

            // act
            IHttpActionResult result = booksController.Get("test");
            var booksResult = result as OkNegotiatedContentResult<List<Book>>;

            // assert
            Assert.IsNotNull(booksResult);
            Assert.IsNotNull(booksResult.Content);
        }

        [Test]
        [Category("GoodAPI Books Tests")]
        public void Get_Test()
        {
            // arrange            
            BooksController booksController = new BooksController(transactionFactoryMock.Object, booksRepositoryMock.Object);
            booksController.Request = new HttpRequestMessage();
            booksController.Configuration = new HttpConfiguration();

            // act
            IHttpActionResult result = booksController.Get();
            var booksResult = result as OkNegotiatedContentResult<List<Book>>;

            // assert
            Assert.IsNotNull(booksResult);
            Assert.IsNotNull(booksResult.Content);
        }

        [Test]
        [Category("GoodAPI Books Tests")]
        public void Post_Test()
        {
            // arrange            
            BooksController booksController = new BooksController(transactionFactoryMock.Object, booksRepositoryMock.Object);
            booksController.Request = new HttpRequestMessage();
            booksController.Configuration = new HttpConfiguration();

            Book book = new Book
            {
                ID = 2,
                Author = "Some Guy",
                PublishDate = DateTime.Now,
                Publisher = "Bizstream",
                Title = "Another test"
            };

            // act
            IHttpActionResult result = booksController.Post(book);
            var booksResult = result as CreatedNegotiatedContentResult<Book>;

            // assert
            Assert.IsNotNull(booksResult);
            Assert.IsNotNull(booksResult.Content);
        }

    }
}
