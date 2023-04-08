namespace Domain.DTOs.Responses.Customers;

public class CreateCustomerDto
{

	public CreateCustomerDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}
