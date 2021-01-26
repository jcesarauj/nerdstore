using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events
{
	public class DraftOrderStartedEvent : Event
	{
		public DraftOrderStartedEvent(Guid clientId, Guid orderId)
		{
			ClientId = clientId;
			OrderId = orderId;
			AgregatedId = orderId;
		}

		public Guid ClientId { get; private set; }
		public Guid OrderId { get; private set; }
	}
}
