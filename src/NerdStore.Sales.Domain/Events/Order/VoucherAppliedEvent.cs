using NerdStore.Core.Messages;
using System;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class VoucherAppliedEvent : Event
	{
        public Guid ClientId { get; private set; }
        public Guid OrderId { get; private set; }
        public Guid VoucherId { get; private set; }

        public VoucherAppliedEvent(Guid clientId, Guid orderId, Guid voucherId)
        {
            AgregatedId = orderId;
            ClientId = clientId;
            OrderId = orderId;
            VoucherId = voucherId;
        }
    }
}
