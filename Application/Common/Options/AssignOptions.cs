
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Application.Common.Options;

public class AssignOptions
{
	public List<Client>? Clients { get; set; }
}

public class Client
{
	public string? Title { get; set; }
	[JsonIgnore]
	public string? Name { get; set; }
	public string? Nin { get; set; }
	public string? FromDate { get; set; }
	[JsonIgnore]
	public SejamStatus[]? RealPersonValidSejamStatus { get; set; }
	[JsonIgnore]
	public SejamStatus[]? LegalPersonValidSejamStatus { get; set; }
	[JsonIgnore]
	public string? NotDefined { get; set; }
	public string? SymbolPattern { get; set; }
}




public enum SejamStatus
{
	noProfile = 0,
	init = 1,
	successPayment = 2,
	policyAccepted = 3,
	pendingValidation = 4,
	invalidInformation = 5,
	traceCode = 6,
	Sejami = 7,
	suspend = 8,
	dead = 9,
	semiSejami = 10
}