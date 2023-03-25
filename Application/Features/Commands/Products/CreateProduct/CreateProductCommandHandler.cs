using Application.Interfaces;
using Domain.DTOs.Responses.Products;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Commands.Products.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
{
	private readonly IApplicationDbContext _context;
	private readonly IEnumerable<IValidator> _validators;
	public CreateProductCommandHandler(IApplicationDbContext context,IEnumerable<IValidator<CreateProductCommand>> validators)
	{
		_context = context;
		_validators = validators;
	}
	public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var movie = request.MapTo();
		var entityEntry = _context.Products.Add(movie);
		var result = await _context.SaveChangesAsync();
		return new CreateProductDto(id: result);
	}


}

//public class CreateProductPiplene<CreateProductCommand, CreateProductDto> : IPipelineBehavior<CreateProductCommand, CreateProductDto>
//{
//	public Task<CreateProductDto> Handle(CreateProductCommand request, RequestHandlerDelegate<CreateProductDto> next, CancellationToken cancellationToken)
//	{
//		throw new System.NotImplementedException();
//	}
//}