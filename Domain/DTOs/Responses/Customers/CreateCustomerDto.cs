using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses.Customers;

public class CreateCustomerDto
{
	public CreateCustomerDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}
