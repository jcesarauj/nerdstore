using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation;
using System;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class AddCartItemCommand : Command
	{
		public Guid ProductId { get;  set; }
		public int Quantity { get;  set; }

		public bool IsValid()
		{
			return true;
		}
	}
}
