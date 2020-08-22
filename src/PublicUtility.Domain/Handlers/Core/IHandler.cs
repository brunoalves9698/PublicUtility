using PublicUtility.Domain.Commands.Core;

namespace PublicUtility.Domain.Handlers.Core
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
