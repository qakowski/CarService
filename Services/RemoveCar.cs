using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SerwisSamochodowy.Commands;
using SerwisSamochodowy.Repositories;

namespace SerwisSamochodowy.Services
{
    public class RemoveCar : IService<RemoveCarCommand>
    {
        private readonly ICarsRepository _carRepository;

        public RemoveCar(ICarsRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(RemoveCarCommand command)
        {
            await _carRepository.RemoveCar(command.CallId.ToObjectId());
        }
    }
}
