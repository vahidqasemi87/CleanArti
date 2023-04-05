using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces;

public interface IUnitOfWork
{
	Task<IDbConnection> ConnectionAsync();
	IDbTransaction Transaction { get; }
	Task StartAsync();
	Task CommitAsync();
	Task RollbackAsync();
}
