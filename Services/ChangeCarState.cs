using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SerwisSamochodowy.Commands;
using SerwisSamochodowy.Data;
using SerwisSamochodowy.Repositories;

namespace SerwisSamochodowy.Services
{
    public class ChangeCarState : IService<ChangeCarStateCommand, Car>
    {
        private readonly ICarsRepository _carRepositroy;

        public ChangeCarState(ICarsRepository carRepository)
        {
            _carRepositroy = carRepository;
        }
        public async Task<Car> Handle(ChangeCarStateCommand command)
        {
            return await _carRepositroy.ChangeState(command.CallId.ToObjectId(), command.State);
        }
    }
}
