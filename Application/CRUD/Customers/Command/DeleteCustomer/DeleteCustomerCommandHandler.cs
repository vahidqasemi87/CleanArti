using Application.Common.Interfaces.Learning02;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Customers.Command.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, int>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly ICustomerRepository _customerRepository;
	public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
	{
		_unitOfWork = unitOfWork;
		_customerRepository = customerRepository;
	}
	public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
	{
		
		var findCustomer =
		 await _customerRepository.GetAsync(request.Id);


		if (findCustomer != null)
		{
			
			await _unitOfWork.Customers.Delete(findCustomer.Id);
			var resultId =
				await _unitOfWork.CompleteAsync();


			return resultId;

		}
		return 0;

	}
}
