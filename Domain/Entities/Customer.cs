using Domain.Common;
using System.Collections.Generic;

namespace Domain.Entities;

public class Customer:BaseEntity
{
	public Customer()
	{
		//Orders = new List<Order>();
	}
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }

	[System.ComponentModel.DataAnnotations.RegularExpression(@"\d{10}")]
    public string? NationaCode { get; set; }
    public string? Mobile { get; set; }
	public string? Address { get; set; }
	//public IList<Order> Orders { get; set; }
}