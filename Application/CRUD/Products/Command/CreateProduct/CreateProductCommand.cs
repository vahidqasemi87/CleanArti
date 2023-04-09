using Application.Common.Base;
using Domain.DTOs.Responses.Products;
using MediatR;

namespace Application.Features.Products.Command.CreateProduct;

public class CreateProductCommand : //IRequest<CreateProductDto>
	ICommand<CreateProductDto>
{
	public string? Name { get; set; }
	public string? Barcode { get; set; }
	public string? Description { get; set; }
	public decimal Rate { get; set; }
}