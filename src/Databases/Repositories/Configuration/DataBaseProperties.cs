using Patterns.Repositories.Configuration.Interfaces;

namespace Patterns.Repositories.Configuration
{
    public class DataBaseProperties : IDataBaseProperties
    {
        public DataBaseProperties(string connectionStringName)
        {
            ConnectionStringName = connectionStringName;
        }

        public string ConnectionStringName { get; }
    }
}
