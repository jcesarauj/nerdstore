using NerdStore.Core.DomainObjects.Dtos.Order;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
	public class OrderProcessCancelEvent : IntegrationEvent
    {
        public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public  ListProductsOrder ProductsOrder { get; private set; }

        public OrderProcessCancelEvent(Guid orderId, Guid clientId, ListProductsOrder productsOrder)
        {
            AgregatedId = orderId;
            OrderId = orderId;
            ClientId = clientId;
            ProductsOrder = productsOrder;
        }
    }
}
