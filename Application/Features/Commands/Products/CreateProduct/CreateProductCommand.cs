using MediatR;
using Domain.DTOs.Responses.Products;

namespace Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductDto>
{
	public string? Name { get; set; }
	public string? Barcode { get; set; }
	public string? Description { get; set; }
	public decimal Rate { get; set; }
}