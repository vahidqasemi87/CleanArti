using Step01;
using System;

namespace Step03;

public interface IIdempotentCommand<out TResponse> : ICommand<TResponse>
{
	Guid RequestId { get; set; }
}
