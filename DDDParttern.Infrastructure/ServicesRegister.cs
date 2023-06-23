using DDDParttern.Domain.IRepository;
using DDDParttern.Infrastructure.Context;
using DDDParttern.Infrastructure.Context.IContext;
using DDDParttern.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDParttern.Infrastructure
{

    public static class ServicesRegister
    {
        public static IConfiguration configuration { get; set; }

        public static void AddInfrastructureLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Database
            serviceCollection.AddDbContext<SQLServerContext>(options =>
            {
                options.UseSqlServer(configuration["SQLServerContext:ConnectionStr"], b => b.MigrationsAssembly("DDDParttern.API"));
            });

            serviceCollection.AddDbContext<SQLServerContextReadonly>(options =>
            {
                options.UseSqlServer(configuration["SQLServerContext:ConnectionStr"], b => b.MigrationsAssembly("DDDParttern.API"));
            });

            serviceCollection.AddScoped<IMongoContext, MongoContext>();
            serviceCollection.AddScoped<IRedisContext, RedisContext>();

            // Service
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            serviceCollection.AddScoped(typeof(IRepositoryReadonly<>), typeof(RepositoryReadonly<>));


        }
    }
}
