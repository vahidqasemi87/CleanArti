namespace Domain.DTOs.Requests.Product;

public class CreateProductRequest
{
	public string? Name { get; set; }
	public string? Barcode { get; set; }
	public string? Description { get; set; }
	public decimal Rate { get; set; }
}
