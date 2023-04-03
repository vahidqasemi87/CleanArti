using Domain.Common;
using System;

namespace Domain.Entities;

public class Order : BaseEntity
{
	public Order()
	{
		Customer = new Customer();
	}
	public DateTime? OrderDate { get; set; }
	public bool IsPayed { get; set; } = false;
	public bool IsSend { get; set; } = false;
	public string? PaymentCode { get; set; }
	public Customer Customer { get; set; }
    public decimal Price { get; set; }
}