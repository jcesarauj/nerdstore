using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation;
using System;

namespace NerdStore.Sales.Domain.Commands
{
	public class AddCartItemCommand : Command
	{
		public Guid ProductId { get; private set; }
		public int Quantity { get; private set; }

		public bool IsValid()
		{
			return true;
		}
	}
}
