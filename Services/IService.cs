using System.Threading.Tasks;
using SerwisSamochodowy.Commands;

namespace SerwisSamochodowy.Services
{
    public interface IService<in TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
