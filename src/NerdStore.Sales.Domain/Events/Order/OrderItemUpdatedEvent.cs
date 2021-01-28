using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderItemUpdatedEvent : Event
	{
		

		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }
		public decimal TotalValue { get; private set; }

		public OrderItemUpdatedEvent(Guid clientId, Guid orderId, decimal totalValue)
		{
			ClientId = clientId;
			OrderId = orderId;
			AgregatedId = orderId;
			TotalValue = totalValue;
		}
	}
}
