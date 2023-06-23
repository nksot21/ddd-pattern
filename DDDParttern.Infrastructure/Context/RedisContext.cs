using DDDParttern.Infrastructure.Context.IContext;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure.Context
{
    public class RedisContext : IRedisContext
    {
        private readonly Lazy<ConnectionMultiplexer> lazyConnection;
        public RedisContext(IConfiguration configuration)
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() => {
                return ConnectionMultiplexer.Connect(configuration["RedisDBSettings:ConnectionString"]);
            });
        }

        public ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
