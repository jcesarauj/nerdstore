using NerdStore.Core.Messages;
using NerdStore.Sales.Api.Application.Validation;
using System;

namespace NerdStore.Sales.Api.Application.Commands
{
	public class AddOrderItemCommand : Command
	{
		public AddOrderItemCommand(Guid productId, Guid clientId, string productName, decimal unitaryValue, int quantity)
		{
			ProductId = productId;
			ClientId = clientId;
			ProductName = productName;
			UnitaryValue = unitaryValue;
			Quantity = quantity;
		}

		public Guid ProductId { get; private set; }
		public Guid ClientId { get; private set; }
		public string ProductName { get; private set; }
		public decimal UnitaryValue { get; private set; }
		public int Quantity { get; private set; }

		public bool IsValid()
		{
			ValidationResult = new AddOrderItemValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
