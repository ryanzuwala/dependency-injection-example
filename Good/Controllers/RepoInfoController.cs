using System;
using System.Web.Http;
using DependencyInjection.Common.Repositories;

namespace Good.Controllers
{
    public class RepoInfoController : ApiController
    {
        private readonly IBooksRepository booksRepository;

        public RepoInfoController(IBooksRepository booksRepository)
        {

            if (booksRepository == null)
            {
                throw new ArgumentNullException("booksRepository is null!!!!");
            }

            this.booksRepository = booksRepository;
        }

        public IHttpActionResult Get()
        {
            return Ok(this.booksRepository.RepositoryInfo);
        }
    }
}
