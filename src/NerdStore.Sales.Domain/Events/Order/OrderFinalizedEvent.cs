using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Events.Order
{
	public class OrderFinalizedEvent : Event
	{
		public Guid OrderId { get; private set; }
		public OrderFinalizedEvent(Guid orderId)
		{
			OrderId = orderId;
		}
	}
}
