using Application.Features.Customers.Command.CreateCustomer;
using Application.Features.Orders.Command.CreateOrder;
using AutoMapper;
using Domain.DTOs.Responses.Customers;
using Domain.DTOs.Responses.Orders;
using Domain.Entities;

namespace Application.Common.Mappings;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
		//CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
		//CreateMap<CreateCustomerDto, Customer>().ReverseMap();


		//CreateMap<Product, CreateOrderCommand>();
		//CreateMap<CreateOrderDto, Product>().ReverseMap();

		//CreateMap<Order, CreateOrderCommand>();
		//CreateMap<CreateOrderDto, Order>().ReverseMap();
	}
}
