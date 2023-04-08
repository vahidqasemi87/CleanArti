using Domain.Entities;

namespace Application.Features.Products.Command.CreateProduct;

public static class CreateProductCommandExtension
{

	public static Product MapTo(this CreateProductCommand command)
	{
		var product = new Product
		{
			Name = command.Name,
			Description = command.Description,
			Barcode = command.Barcode,
			Rate = command.Rate,
		};
		return product;
	}
}
