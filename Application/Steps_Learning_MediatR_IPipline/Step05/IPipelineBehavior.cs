using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Step05;

public interface IPipelineBehavior<in TRequest, TResponse> where TRequest : notnull, MediatR.IRequest<TResponse>
{
	Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next);
}
