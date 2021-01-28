using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderProductUpdatedEvent : Event
	{
		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }
		public Guid ProductId { get; private set; }
		public int Quantity { get; private set; }

		public OrderProductUpdatedEvent(Guid clientId, Guid orderId, Guid productId, int quantity)
		{
			ClientId = clientId;
			OrderId = orderId;
			ProductId = productId;
			Quantity = quantity;
		}
	}
}
