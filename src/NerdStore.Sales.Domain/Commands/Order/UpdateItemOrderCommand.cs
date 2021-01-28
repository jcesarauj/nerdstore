using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation.Command.Order;
using System;

namespace NerdStore.Sales.Domain.Commands.Order
{
	public class UpdateItemOrderCommand : Command
	{
		public Guid ClientId { get; private set; }
		public Guid ProductId { get; private set; }
		public int Quantity { get; private set; }

		public UpdateItemOrderCommand(Guid clientId, Guid productId, int quantity)
		{
			ClientId = clientId;
			ProductId = productId;
			Quantity = quantity;
		}

		public override bool IsValid()
		{
			ValidationResult = new UpdateItemOrderValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
