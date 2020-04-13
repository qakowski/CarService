using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SerwisSamochodowy.Mongo
{
    public static class Extension
    {
        public static void AddMongo(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MongoOptions>("mongo");

                return options;
            });

            builder.Register(context =>
            {
                var options = context.Resolve<MongoOptions>();
                return new MongoClient(options.ConnectionString);
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoOptions>();
                var client = context.Resolve<MongoClient>();

                return client.GetDatabase(options.DbName);
            }).InstancePerLifetimeScope();
        }

        public static void AddRepository<TEntity>(this ContainerBuilder builder, string collection) where TEntity : IBase
        {
            builder.Register(context =>
                new Seeder<TEntity>(context.Resolve<MongoClient>()))
                .As<IStartable>()
                .SingleInstance();

            builder.Register(context =>
             new Repository<TEntity>(context.Resolve<IMongoDatabase>(), collection)
            ).As<IRepository<TEntity>>().InstancePerLifetimeScope();
        }

        private static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(section).Bind(model);

            return model;
        }
    }
}
