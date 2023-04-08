using MediatR;

namespace Application.Features.Products.Command.DeleteProduct;

public class DeleteProductByIdCommand : IRequest<int>
{
	public int Id { get; set; }
}