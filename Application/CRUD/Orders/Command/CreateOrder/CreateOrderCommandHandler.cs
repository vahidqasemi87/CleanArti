using Application.Interfaces;
using Domain.DTOs.Responses.Orders;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Orders.Command.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderDto>
{
    private readonly IApplicationDbContext _context;


    //هر کسی بخواهد از این کلاس استفاده کند باید باید
    //  باید بگه تو باید با این 
    //CalculateFinalPrice
    //  کار محاسبه را انجام بده
    private readonly CalculateFinalPrice _calculateFinalPrice;
    public CreateOrderCommandHandler(IApplicationDbContext context, CalculateFinalPrice calculateFinalPrice)
    {
        _context = context;
        _calculateFinalPrice = calculateFinalPrice;
    }
    public async Task<CreateOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order =
            request.MapTo();

        var customer = _context
            .Customers
            .Where(w => w.Id == request.CustomerId)
            .FirstOrDefault();

        var checkLastBuy =
            _context.Orders.Where(w => w.Customer.Id == request.CustomerId).FirstOrDefault()?.OrderDate;


        decimal finalPriceCalculator =
            _calculateFinalPrice.Calculate(orderDate: checkLastBuy, price: order.Price);

        order.Price = finalPriceCalculator;

        if (customer != null)
            order.Customer = customer;



        var entityEntry =
            await _context.Orders.AddAsync(entity: order);

        var orderId = await _context.SaveChangesAsync();

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
