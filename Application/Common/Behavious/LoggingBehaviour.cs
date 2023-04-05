using Application.Common.Base;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behavious
{
	public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : class, IRequest<TResponse>
	{

		private ILogger<TRequest> Logger { get; }
		public LoggingBehaviour(ILogger<TRequest> logger)
		{
			Logger = logger;
		}
		public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			var requestStart = "{QueryName}";
			var requestEnd = "{QueryName} after {ElapsedTime}ms";
			EventId eventIdStart = EventIds.QueryStart;
			EventId eventIdEnd = EventIds.QueryEnd;

			if (typeof(TRequest).GetInterfaces().Any(x => x == typeof(ICommandBase)))
			{
				requestStart = "{CommandName}";
				requestEnd = "{CommandName} after {ElapsedTime}ms";
				eventIdStart = EventIds.CommandStart;
				eventIdEnd = EventIds.CommandEnd;
			}

			using (LogContext.PushProperty("@body", request, true))
			{
				Logger.LogDebug(eventIdStart, requestStart, typeof(TRequest).Name);
			}

			var sw = new Stopwatch();
			sw.Start();
			var result = next();
			sw.Stop();

			var miliSecond = sw.ElapsedMilliseconds;

			using (LogContext.PushProperty("@Result", result.Result, true))
			{
				Logger.LogDebug(eventIdEnd, requestEnd, typeof(TRequest).Name, miliSecond);
			}

			return result;
		}
	}
}
