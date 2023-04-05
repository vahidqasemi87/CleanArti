using Application.Common.Interfaces.Learning;
using Application.Common.Z;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behavious;

public class UnitOfWorkBehaviour<TRequest, TResponse>
	: IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
	private readonly IUnitOfWork_New _unitOfWork;
	private readonly ILogger<TRequest> _logger;
	public UnitOfWorkBehaviour(IUnitOfWork_New unitOfWork, ILogger<TRequest> logger)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
	}

	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		//_logger.LogDebug(EventIds.Transaction, "Start");
		//await _unitOfWork.StartAsync();

		try
		{
			TResponse? result = await next();

			Result? f = result as Result;

			if (f != null && f.IsFailed)
			{
				await _unitOfWork.RollbackAsync();
				_logger.LogDebug(EventIds.Transaction, "Rollback");
			}
			else
			{
				await _unitOfWork.CommitAsync();
				_logger.LogDebug(EventIds.Transaction, "Commit");
			}
			return result;
		}
		catch (Exception)
		{
			await _unitOfWork.RollbackAsync();
			_logger.LogDebug(EventIds.Transaction, "Rollback");
			throw;
		}
	}
}
