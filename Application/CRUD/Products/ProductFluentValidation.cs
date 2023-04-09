using Application.Features.Products.Command.CreateProduct;
using FluentValidation;

namespace Application.CRUD.Products;

public class ProductFluentValidation : AbstractValidator<CreateProductCommand>
{
    public ProductFluentValidation()
    {
        RuleFor(expression: c => c.Barcode)
            .NotNull()
            .WithMessage(errorMessage: "Barcode is requierd")
            .NotEmpty()
            .WithMessage(errorMessage: "Barcode is requierd")
            .Length(min: 1, max: 250)
            .WithMessage(errorMessage: "range  1 , 250");

        RuleFor(expression: c => c.Description)
            .Length(min: 0, max: 500);
        RuleFor(expression: c => c.Name)
            .NotEmpty()
            .NotNull()
            .Length(min: 3, max: 50);
    }
}
