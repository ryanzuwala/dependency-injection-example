using System.Configuration;
using System.Web.Http;
using Bad.Repositories.SqlServer;

namespace Bad.Controllers
{
    public class RepoInfoController : ApiController
    {
        private readonly SqlServerBooksRepository booksRepository;

        public RepoInfoController()
        {
            this.booksRepository = new SqlServerBooksRepository(ConfigurationManager.ConnectionStrings["books_mssql_database"].ConnectionString);
        }

        public IHttpActionResult Get()
        {
            return Ok(this.booksRepository.RepositoryInfo);
        }
    }
}
