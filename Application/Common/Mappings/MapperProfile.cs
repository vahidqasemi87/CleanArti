using Application.Features.Customers.Command.CreateCustomer;
using Application.Features.Orders.Command.CreateOrder;
using Application.Features.Products.Command.CreateProduct;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings;

public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
		CreateMap<Order, CreateOrderCommand>().ReverseMap();
		CreateMap<Product, CreateProductCommand>().ReverseMap();
		//CreateMap<CreateCustomerCommand, Customer>().ReverseMap();
		//CreateMap<CreateCustomerDto, Customer>().ReverseMap();


		//CreateMap<Product, CreateOrderCommand>();
		//CreateMap<CreateOrderDto, Product>().ReverseMap();

		//CreateMap<Order, CreateOrderCommand>();
		//CreateMap<CreateOrderDto, Order>().ReverseMap();
	}
}
