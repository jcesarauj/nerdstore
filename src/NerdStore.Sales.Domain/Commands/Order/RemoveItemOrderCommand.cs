using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation.Command.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Order
{
	public class RemoveItemOrderCommand : Command
	{
		public Guid ClientId { get; private set; }
		public Guid ProductId { get; private set; }
		//public int Quantity { get; private set; }

		public RemoveItemOrderCommand(Guid clientId, Guid productId/*, int quantity*/)
		{
			ClientId = clientId;
			ProductId = productId;
			//Quantity = quantity;
		}

		public override bool IsValid()
		{
			ValidationResult = new RemoveItemOrderValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
