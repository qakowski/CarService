using System.Threading.Tasks;
using SerwisSamochodowy.Commands;

namespace SerwisSamochodowy.Services
{
    public interface IService<in TCommand, TResult> where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
    public interface IService<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}
