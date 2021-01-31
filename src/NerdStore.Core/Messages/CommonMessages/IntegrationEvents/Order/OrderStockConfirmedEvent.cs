using NerdStore.Core.DomainObjects.Dtos.Order;
using System;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents
{
	public class OrderStockConfirmedEvent : IntegrationEvent
    {
		public OrderStockConfirmedEvent(Guid orderId, Guid clientId, decimal total, ListProductsOrder productsOrder, string cardName, string cardNumber, string expiration, string cvv)
		{
			AgregatedId = orderId;
			OrderId = orderId;
			ClientId = clientId;
			Total = total;
			ProductsOrder = productsOrder;
			CardName = cardName;
			CardNumber = cardNumber;
			Expiration = expiration;
			Cvv = cvv;
		}

		public Guid OrderId { get; private set; }
        public Guid ClientId { get; private set; }
        public decimal Total { get; private set; }
        public ListProductsOrder ProductsOrder { get; private set; }
        public string CardName { get; private set; }
        public string CardNumber { get; private set; }
        public string Expiration { get; private set; }
        public string Cvv { get; private set; }

        
    }
}