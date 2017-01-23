using System.Configuration;
using System.Web.Http;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.SqlServer;
using DependencyInjection.Repositories.SqlServer.Transactions;
using LightInject;

namespace Good.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            ServiceContainer container = new ServiceContainer();

            // register transaction context
            container.Register<ITransactionFactory>(x => new SqlServerTransactionFactory(
                ConfigurationManager.ConnectionStrings["books_database"].ConnectionString), 
                new PerScopeLifetime());

            // register repositories
            container.Register<IBooksRepository>(x => new SqlServerBooksRepository(), new PerContainerLifetime());

            container.EnableWebApi(config);
            container.RegisterApiControllers();
        }
    }
}