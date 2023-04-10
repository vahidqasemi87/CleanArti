using Application.Common.Interfaces.Learning02;
using AutoMapper;
using Domain.DTOs.Responses.Products;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Products.Command.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly IProductRepository _productRepository;

	private readonly IMapper _mapper;

	private readonly IValidator<CreateProductCommand> _validator;

	public CreateProductCommandHandler(
		IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper, IValidator<CreateProductCommand> validator
		)
	{
		
		_unitOfWork = unitOfWork;
		_productRepository = productRepository;
		_mapper = mapper;
		_validator = validator;
	}
	public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		ValidationResult validationResult =
			await _validator.ValidateAsync(request);

		if (!validationResult.IsValid)
		{
			// to do
		}

		var product = new Product();

		product = _mapper.Map<Product>(request);

		await _productRepository.AddAsync(product);
		var result = await _unitOfWork.CompleteAsync();
		return new CreateProductDto(id: result);

	}
}