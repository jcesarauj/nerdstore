using NerdStore.Core.DomainObjects.Dtos.Order;
using System;

namespace NerdStore.Core.Messages.CommonMessages.IntegrationEvents.Order
{
	public class StartOderEvent : IntegrationEvent
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }
		public decimal Total { get; private set; }
		public ListProductsOrder ProductsOrder { get; private set; }
		public string CardName { get; private set; }
		public string CardNumber { get; private set; }
		public string Expiration { get; private set; }
		public string Cvv { get; private set; }

		public StartOderEvent(Guid orderId, Guid clientId, decimal total, ListProductsOrder produtosPedido, string cardName, string cardNumber, string expiration, string cvv)
		{
			OrderId = orderId;
			ClientId = clientId;
			Total = total;
			ProdutosPedido = produtosPedido;
			CardName = cardName;
			CardNumber = cardNumber;
			Expiration = expiration;
			Cvv = cvv;
		}
	}
}
