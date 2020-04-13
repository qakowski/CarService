using MongoDB.Bson;

namespace SerwisSamochodowy.Mongo
{
    public interface IBase
    {
        public ObjectId Id { get; set; }
    }
}