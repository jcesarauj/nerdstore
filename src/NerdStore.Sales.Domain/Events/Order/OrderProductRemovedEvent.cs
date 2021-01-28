using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderProductRemovedEvent : Event
	{
		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }
		public Guid ProductId { get; private set; }

		public OrderProductRemovedEvent(Guid clientId, Guid orderId, Guid productId)
		{
			AgregatedId = orderId;
			ClientId = clientId;
			OrderId = orderId;
			ProductId = productId;
		}
	}
}
