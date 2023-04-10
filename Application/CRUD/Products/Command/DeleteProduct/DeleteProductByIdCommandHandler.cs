using Application.Common.Interfaces.Learning02;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.DeleteProduct;

public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
{
	
	private readonly IUnitOfWork _unitOfWork;
	private readonly IProductRepository _productRepository;
	public DeleteProductByIdCommandHandler( IUnitOfWork unitOfWork, IProductRepository productRepository)
	{
		_unitOfWork = unitOfWork;
		_productRepository = productRepository;
	}
	public async Task<int> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
	{
		//var findedProduct =
		//	await _context.Products.Where(w => w.Id == request.Id).FirstOrDefaultAsync();

		var findedProduct =
			await _productRepository.GetAsync(request.Id);

		if (findedProduct != null)
		{
			await _productRepository.Delete(findedProduct.Id);
			//_context.Products.Remove(findedProduct);

			//var finalId =
			//	await _context.SaveChangesAsync();

			var finalId =
				await _unitOfWork.CompleteAsync();

			return finalId;
		}
		return 0;
	}
}