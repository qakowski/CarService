using System.Threading.Tasks;

namespace SerwisSamochodowy.Mongo
{
    public interface ISeeder<TEntity> where TEntity : IBase
    {
        Task CreateCollectionIfNotExisting(string databaseName);
    }
}
