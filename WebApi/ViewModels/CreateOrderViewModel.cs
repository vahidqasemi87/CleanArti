using Domain.Entities;
using System;

namespace WebApi.ViewModels;

public class CreateOrderViewModel
{
    public CreateOrderViewModel(int customerId)
    {
        //Customer = new Customer();
        CustomerId = customerId;
    }
    public DateTime? OrderDate { get; set; }
	public bool IsPayed { get; set; } = false;
	public bool IsSend { get; set; } = false;
	public string? PaymentCode { get; set; }
    public decimal Price { get; set; }
    public int CustomerId { get; set; }
    //public Customer? Customer { get; set; }
}
