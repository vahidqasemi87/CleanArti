using MediatR;

namespace Application.Common.Base
{
	public interface IQuery<out TResponse> : IRequest<TResponse>
	{
	}
}
