namespace NerdStore.Payments.Business.Contracts
{
    public interface IConfigurationManager
    {
        string GetValue(string node);
    }
}