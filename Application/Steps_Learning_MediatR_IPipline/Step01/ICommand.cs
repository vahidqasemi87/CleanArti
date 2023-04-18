using MediatR;

namespace Step01;

//Step 01

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
public interface IQuery<out TRespone> : IRequest<TRespone>
{

}