using Application.Common.Interfaces.Learning;
using Application.Interfaces;
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
    //private readonly IApplicationDbContext _context;
    private readonly IUnitOfWork_New _unitOfWork_New;
    private readonly IRepository_New<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly IEnumerable<IValidator> _validators;
    public CreateProductCommandHandler( IEnumerable<IValidator<CreateProductCommand>> validators, IUnitOfWork_New unitOfWork_New, IRepository_New<Product> repository_New, IMapper mapper)
    {
        _validators = validators;
        _unitOfWork_New = unitOfWork_New;
        _productRepository = repository_New;
        _mapper = mapper;
    }
    public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var tt = _validators.Any();

        //var movie = request.MapTo();
        var product = new Product();

		product = _mapper.Map<Product>(request);

        _productRepository.Add(product);
         var result = await _unitOfWork_New.SaveChangesAsync();
        return new CreateProductDto(id: result);
    }


}