using MediatR;

namespace Application.Features.Products.Command.UpdateProduct;

public class UpdateProductCommand : IRequest<int>
{
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Barcode { get; set; }
	public string? Description { get; set; }
	public decimal Rate { get; set; }
}