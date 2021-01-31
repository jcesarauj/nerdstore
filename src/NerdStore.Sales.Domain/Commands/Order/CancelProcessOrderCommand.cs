using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Commands.Order
{
	public class CancelProcessOrderCommand : Command
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }

		public CancelProcessOrderCommand(Guid orderId, Guid clientId)
		{
			OrderId = orderId;
			ClientId = clientId;
		}
	}
}
