using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Infrastructure.Persistence
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string DefaultCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string DefaultCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
