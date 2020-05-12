using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using SerwisSamochodowy.Data;
using SerwisSamochodowy.Mongo;
using SerwisSamochodowy.Commands;
using MongoDB.Driver;

namespace SerwisSamochodowy.Repositories
{
    public class CarsRepository : ICarsRepository
    {
        private readonly IRepository<Car> _repository;

        public CarsRepository(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<Car> AddCar(Car car) 
            => await _repository.AddAsync(car);

        public async Task<Car> ChangeState(ObjectId id, StateEnum state)
        {
            var filterDefinition = Builders<Car>.Filter.Eq(p => p.Id, id);
            var updateDefinition = Builders<Car>.Update.Set(p => p.State, state);
            return await _repository.UpdateAsync(filterDefinition, updateDefinition);
        }

        public async Task<IEnumerable<Car>> FindCars(string clientName, ObjectId callId, string producer, string model)
        {
            Expression<Func<Car, bool>> clientNamePredicate = p => true;
            Expression<Func<Car, bool>> callIdPredicate = p => true;
            Expression<Func<Car, bool>> producerPredicate = p => true;
            Expression<Func<Car, bool>> modelPredicate = p => true;

            if (!string.IsNullOrEmpty(clientName))
                clientNamePredicate = p => p.Client.SureName.Contains(clientName);

            if (!ObjectId.Empty.Equals(callId))
                callIdPredicate = p => p.Id.Equals(callId);

            if (!string.IsNullOrEmpty(producer))
                producerPredicate = p => p.Producer.Contains(producer);

            if (!string.IsNullOrEmpty(model))
                modelPredicate = p => p.Model.Contains(model);

            Expression<Func<Car, bool>> combinedPredicate = p => 
            clientNamePredicate.Invoke(p) && 
            callIdPredicate.Invoke(p) && 
            producerPredicate.Invoke(p) && 
            modelPredicate.Invoke(p);

            return await _repository.FindAsync(combinedPredicate.Expand());
        }

        public async Task<Car> GetCar(ObjectId id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task RemoveCar(ObjectId id)
        {
            await _repository.DeleteAsync(id); 
        }
    }
}
