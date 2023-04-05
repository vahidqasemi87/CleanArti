using Application.Common.Interfaces.Learning;
using Application.Interfaces;
using AutoMapper;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
{
	private readonly IUnitOfWork_New _unitOfWork_New;
	private readonly IRepository_New<Order> _orderRepository;
	private readonly IRepository_New<Customer> _customerRepository;
	private readonly IMapper _mapper;
	private readonly CalculateFinalPrice _calculateFinalPrice;



	public CreateOrderCommandHandler(IUnitOfWork_New unitOfWork_New, IRepository_New<Order> repository_New, IMapper mapper, CalculateFinalPrice calculateFinalPrice, IRepository_New<Customer> customerRepository)
	{
		_unitOfWork_New = unitOfWork_New;
		_customerRepository = customerRepository;
		_mapper = mapper;
		_calculateFinalPrice = calculateFinalPrice;
	}
	public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{
		//var order =
		//    request.MapTo();


		var order = new Order();

		order = _mapper.Map<Order>(request);


		var customer = await _customerRepository.GetByIdAsync(request.CustomerId);



		var checkLastBuy =
			await _orderRepository.GetByIdAsync(customer.Id);
		//_context.Orders.Where(w => w.Customer.Id == request.CustomerId).FirstOrDefault()?.OrderDate;


		decimal finalPriceCalculator =
			_calculateFinalPrice.Calculate(orderDate: checkLastBuy.OrderDate, price: order.Price);

		order.Price = finalPriceCalculator;

		if (customer != null)
			order.Customer = customer;




		_orderRepository.Add(order);
		var orderId = await _unitOfWork_New.SaveChangesAsync();
		//await _context.Orders.AddAsync(entity: order);

		//var orderId = await _context.SaveChangesAsync();

		return new CreateOrderDto(id: orderId);
	}
}


public class CalculateFinalPrice
{
	public decimal Calculate(DateTime? orderDate, decimal price)
	{
		if (orderDate == null) return price;

		if (orderDate >= DateTime.Now.AddDays(-7)) return price - 20;
		if (orderDate >= DateTime.Now.AddDays(-14)) return price - 15;

		return price;
	}
}
