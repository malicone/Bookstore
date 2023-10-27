using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public class ConnectionFactory
    {        
        public static FbConnection GetConnectionAsSingleton()
        {
            if (_connection == null)
            {
                string connectionString = GetConnectionString();
                _connection = new FbConnection(connectionString);
            }
            return _connection;
        }

        private static string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
            return config["ConnectionString"];
        }

        private static FbConnection _connection;
    }
}
