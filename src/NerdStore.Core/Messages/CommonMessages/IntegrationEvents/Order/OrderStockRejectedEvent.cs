using System;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
    public class OrderStockRejectedEvent : IntegrationEvent
    {
		public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }

		public OrderStockRejectedEvent(Guid orderId, Guid clientId)
		{
			AgregatedId = orderId;
			OrderId = orderId;
			ClientId = clientId;
		}
	}
}