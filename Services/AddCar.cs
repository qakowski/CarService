using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using SerwisSamochodowy.Commands;
using SerwisSamochodowy.Data;
using SerwisSamochodowy.Repositories;

namespace SerwisSamochodowy.Services
{
    public class AddCar : IService<AddCarCommand, Car>
    {
        private readonly ICarsRepository _carsRepository;

        public AddCar(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }
        public async Task<Car> Handle(AddCarCommand command)
        {
            
            var car = new Car()
            {
                Id = ObjectId.Empty,
                Model = command.Model,
                Client = new Client()
                {
                    ForeName = command.ClientForeName,
                    SureName = command.ClientSureName
                },
                Description = command.Description,
                Photo = command.Photo,
                Producer = command.Producer,
                Received = command.Received,
                State = command.State
            };
            return await _carsRepository.AddCar(car);
        }
    }
}
