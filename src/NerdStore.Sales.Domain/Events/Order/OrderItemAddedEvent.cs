using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderItemAddedEvent : Event
	{
		

		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }
		public Guid ProductId { get; private set; }
		public decimal UnitaryValue { get; private set; }
		public int Quantity { get; private set; }

		public OrderItemAddedEvent(Guid clientId, Guid orderId, Guid productId, decimal unitaryValue, int quantity)
		{
			ClientId = clientId;
			OrderId = orderId;
			ProductId = productId;
			UnitaryValue = unitaryValue;
			Quantity = quantity;
			AgregatedId = orderId;
		}
	}
}
