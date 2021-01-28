using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation;
using System;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class UpdateCartItemCommand : Command
	{
		public Guid OrderItemId { get;  set; }
		public Guid ProductId { get;  set; }
		public int Quantity { get;  set; }

		public bool IsValid()
		{
			return true;
		}
	}
}
