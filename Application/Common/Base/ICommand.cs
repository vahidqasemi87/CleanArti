using MediatR;

namespace Application.Common.Base;

public interface ICommandBase
{

}

public interface ICommand<out TResponse> : ICommandBase, IRequest<TResponse>
{

}

public interface ICommand : ICommandBase, IRequest
{

}