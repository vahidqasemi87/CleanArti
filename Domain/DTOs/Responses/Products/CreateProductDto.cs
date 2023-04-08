namespace Domain.DTOs.Responses.Products;

public class CreateProductDto
{
	public CreateProductDto(int id)
	{
		Id = id;
	}
	public int Id { get; set; }
}