using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Responses.Product;

public class CreateProductDto
{
	public CreateProductDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}