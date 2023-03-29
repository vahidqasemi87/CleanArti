using Step01;
using MediatR;

namespace Step02;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
	where TCommand : ICommand<TResponse>
{
}


public interface IQueryHandler<in TQuery,TResponse> : IRequestHandler<TQuery,TResponse>
	where TQuery : IQuery<TResponse>
{

}