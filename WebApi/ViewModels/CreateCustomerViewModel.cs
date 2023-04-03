namespace WebApi.ViewModels;

public class CreateCustomerViewModel
{
	public string? Username { get; set; }
	public string? Password { get; set; }
	public string? Family { get; set; }
	public string? Name { get; set; }
	public string? Mobile { get; set; }
	public string? Address { get; set; }


	#region [public string? NationalCode { get; set; }]
	[System.ComponentModel.DataAnnotations.RegularExpression(@"\d{10}", ErrorMessage = "کد ملی باید 10 رقم باشد")]
	public string? NationalCode { get; set; }
	#endregion
}
