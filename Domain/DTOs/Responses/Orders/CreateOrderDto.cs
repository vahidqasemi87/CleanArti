using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses.Orders;

public class CreateOrderDto
{
	public CreateOrderDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}