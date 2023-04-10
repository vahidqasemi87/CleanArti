using Application.Common.Interfaces.Learning02;
using AutoMapper;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly IOrderRepository _orderRepository;

	private readonly ICustomerRepository _customerRepository;

	private readonly IMapper _mapper;

	private readonly CalculateFinalPrice _calculateFinalPrice;



	public CreateOrderCommandHandler(

		IUnitOfWork unitOfWork,
		ICustomerRepository customerRepository,
		IOrderRepository orderRepository,
		IMapper mapper,
		CalculateFinalPrice calculateFinalPrice)
	{

		_unitOfWork = unitOfWork;
		_customerRepository = customerRepository;
		_orderRepository = orderRepository;
		_mapper = mapper;
		_calculateFinalPrice = calculateFinalPrice;
	}
	public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
	{



		var order = new Order();

		order = _mapper.Map<Order>(request);


		var customer = await _customerRepository.GetAsync(request.CustomerId);

		if (customer == null) return null;

		var checkLastBuy =
			await _orderRepository.GetAsync(customer.Id);



		decimal finalPriceCalculator =
			_calculateFinalPrice.Calculate(orderDate: checkLastBuy?.OrderDate, price: order.Price);

		order.Price = finalPriceCalculator;

		if (customer != null)
			order.Customer = customer;




		await _orderRepository.AddAsync(order);
		var orderId = await _unitOfWork.CompleteAsync();


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
