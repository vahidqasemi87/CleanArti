using MediatR;
using Domain.DTOs.Responses.Products;

namespace Application.Features.Products.Command.CreateProduct;

public class CreateProductCommand : IRequest<CreateProductDto>
{
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public decimal Rate { get; set; }
}