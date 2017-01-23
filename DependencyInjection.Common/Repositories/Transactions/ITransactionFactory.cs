namespace DependencyInjection.Common.Repositories.Transactions
{
    public interface ITransactionFactory
    {
        ITransaction Create();
    }
}
