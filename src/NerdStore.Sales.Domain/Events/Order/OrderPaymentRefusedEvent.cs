using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderPaymentRefusedEvent : Event
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }

		public OrderPaymentRefusedEvent(Guid orderId, Guid clientId)
		{
			OrderId = orderId;
			ClientId = clientId;
		}
	}
}
