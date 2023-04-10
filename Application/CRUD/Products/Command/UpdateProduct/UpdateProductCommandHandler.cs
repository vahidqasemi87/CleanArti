using Application.Common.Interfaces.Learning02;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IProductRepository _productRepository;
	public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IProductRepository productRepository)
	{
		_unitOfWork = unitOfWork;
		_productRepository = productRepository;
	}
	public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
	{
		//var findedProduct = await _context.Products.Where(w => w.Id == request.Id)
		//	.FirstOrDefaultAsync();

		var findedProduct =
			await _unitOfWork.Products.GetAsync(request.Id);
		//await _productRepository.GetAsync(request.Id);

		if (findedProduct == null)
			return default;

		findedProduct.Barcode = request.Barcode;
		findedProduct.Name = request.Name;
		findedProduct.Description = request.Description;
		findedProduct.Rate = request.Rate;


		//await _context.SaveChangesAsync();
		await _unitOfWork.CompleteAsync();
		return findedProduct.Id;
	}
}
