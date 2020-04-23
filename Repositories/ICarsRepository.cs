using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using SerwisSamochodowy.Commands;
using SerwisSamochodowy.Data;

namespace SerwisSamochodowy.Repositories
{
    public interface ICarsRepository
    {
        Task<IEnumerable<Car>> FindCars(string clientName, ObjectId callId, string producer, string model);
        Task<Car> AddCar(Car car);
        Task<Car> GetCar(ObjectId id);
        Task<Car> ChangeState(ObjectId id, StateEnum state);
        Task RemoveCar(ObjectId id);
    }
}
