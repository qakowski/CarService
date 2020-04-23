using System.Threading.Tasks;
using SerwisSamochodowy.Commands;
using SerwisSamochodowy.Data;
using SerwisSamochodowy.Repositories;

namespace SerwisSamochodowy.Services
{
    public class GetCar : IService<GetCarCommand, Car>
    {
        private readonly ICarsRepository _repository;

        public GetCar(ICarsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Car> Handle(GetCarCommand command)
        {
            var result = await _repository.GetCar(command.CallId.ToObjectId());
            result.Received.ToLocalTime();
            return result;
        }
    }
}
