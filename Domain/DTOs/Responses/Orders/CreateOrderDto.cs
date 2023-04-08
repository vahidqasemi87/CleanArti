namespace Domain.DTOs.Responses.Orders;

public class CreateOrderDto
{
	public CreateOrderDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}