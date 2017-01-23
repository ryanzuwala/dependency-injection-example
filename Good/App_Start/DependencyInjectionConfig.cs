using System.Configuration;
using System.Web.Http;
using DependencyInjection.Common.Repositories;
using DependencyInjection.Common.Repositories.Transactions;
using DependencyInjection.Repositories.Oracle;
using DependencyInjection.Repositories.Oracle.Transactions;
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

            // SQL SERVER:
            // register transaction context
            container.Register<ITransactionFactory>(x => new SqlServerTransactionFactory(
                ConfigurationManager.ConnectionStrings["books_mssql_database"].ConnectionString),
                new PerScopeLifetime());

            // register repositories
            container.Register<IBooksRepository>(x => new SqlServerBooksRepository(), new PerContainerLifetime());






            // ORACLE:
            //// register transaction context
            //container.Register<ITransactionFactory>(x => new OracleTransactionFactory(
            //    ConfigurationManager.ConnectionStrings["books_oracle_database"].ConnectionString),
            //    new PerScopeLifetime());

            //// register repositories
            //container.Register<IBooksRepository>(x => new OracleBooksRepository(), new PerContainerLifetime());

            container.EnableWebApi(config);
            container.RegisterApiControllers();
        }
    }
}