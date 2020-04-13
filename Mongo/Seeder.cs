using System.Threading.Tasks;
using Autofac;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SerwisSamochodowy.Mongo
{
    public class Seeder<TEntity> : ISeeder<TEntity>, IStartable where TEntity : IBase
    {
        private readonly IMongoClient _client;

        public Seeder(IMongoClient client){
            _client = client;
        }

        public Task CreateCollectionIfNotExisting(string databaseName) 
        {
            var db = _client.GetDatabase(databaseName);
            var filter = new BsonDocument("name", typeof(TEntity).Name+"s");
            if (!db.ListCollections(new ListCollectionsOptions { Filter = filter }).Any()) {
                db.CreateCollection(typeof(TEntity).Name+"s");
            }

            return Task.CompletedTask;
        }

        public void Start()
        {
            CreateCollectionIfNotExisting("CarsService");
        }
    }
}
