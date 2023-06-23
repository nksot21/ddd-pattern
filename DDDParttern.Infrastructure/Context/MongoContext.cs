using DDDParttern.Infrastructure.Context.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DDDParttern.Infrastructure.Context
{
    public class MongoContext : IMongoContext

    {
        private readonly IMongoDatabase MongoDatabase;
        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["UserManagementDatabase:ConnectionString"]);
            MongoDatabase = client.GetDatabase(configuration["UserManagementDatabase:DatabaseName"]);
        }


    }
}
