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
    public class GetCars : IService<GetCarsCommand, IEnumerable<Car>>
    {
        private readonly ICarsRepository _carsRepository;

        public GetCars(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public async Task<IEnumerable<Car>> Handle(GetCarsCommand command)
        {
            return await _carsRepository.FindCars(command.ClientName, command.CallId.ToObjectId(), command.Producer, command.Model);
        }
    }
}
