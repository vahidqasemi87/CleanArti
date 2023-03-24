using MediatR;

namespace Application.Features.Commands.Products.DeleteProduct;

public class DeleteProductByIdCommand : IRequest<int>
{
	public int Id { get; set; }
}