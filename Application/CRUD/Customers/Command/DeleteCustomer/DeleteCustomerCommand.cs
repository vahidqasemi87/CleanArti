using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.Customers.Command.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<int>
{
    public int Id { get; set; }
}
