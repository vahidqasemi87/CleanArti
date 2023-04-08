using Application.Common.Interfaces.Learning02;
using AutoMapper;
using Domain.DTOs.Responses.Products;
using Domain.Entities;
using FluentValidation;
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

	private readonly IEnumerable<IValidator<CreateProductCommand>> _validators;

	public CreateProductCommandHandler(
		IEnumerable<IValidator<CreateProductCommand>> validators, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper
		)
	{
		_validators = validators;
		_unitOfWork = unitOfWork;
		_productRepository = productRepository;
		_mapper = mapper;
	}
	public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
	{
		var tt = _validators.Any();

		var product = new Product();

		product = _mapper.Map<Product>(request);

		await _productRepository.AddAsync(product);
		var result = await _unitOfWork.Complete();
		return new CreateProductDto(id: result);

	}


}