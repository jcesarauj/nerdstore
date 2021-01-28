using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class DraftOrderStartedEvent : Event
	{
		

		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }

		public DraftOrderStartedEvent(Guid clientId, Guid orderId)
		{
			ClientId = clientId;
			OrderId = orderId;
			AgregatedId = orderId;
		}
	}
}
