namespace eazy_transact.Models
{
    public class EazytransactDatabaseSettings : IEazytransactDatabaseSettings
    {
        public string UserCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }

    public interface IEazytransactDatabaseSettings
    {
        string UserCollectionName { get; set; }

        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}
