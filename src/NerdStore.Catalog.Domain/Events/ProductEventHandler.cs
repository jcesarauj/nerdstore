using MediatR;
using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Contracts.Service;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Events
{
	public class ProductEventHandler : INotificationHandler<ProductBelowStockEvent>,
		INotificationHandler<StartOderEvent>,
		INotificationHandler<OrderProcessCancelEvent>
	{
		private readonly IProductRepository _productRepository;
		private readonly IMediatorHandler _mediatorHandler;
		private readonly IStockService _stockService;

		public ProductEventHandler(IProductRepository productRepository, IMediatorHandler mediatorHandler)
		{
			_productRepository = productRepository;
			_mediatorHandler = mediatorHandler;
		}

		public async Task Handle(ProductBelowStockEvent productBelowStockEvent, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetById(productBelowStockEvent.AgregatedId);

			//send email to buing more products
		}

		public async Task Handle(StartOderEvent startOderEvent, CancellationToken cancellationToken)
		{
			var result = await _stockService.DebitListProductsOrder(startOderEvent.ProductsOrder);

			if (result)
			{
				await _mediatorHandler.PublishEvent(new OrderStockConfirmedEvent(startOderEvent.OrderId, startOderEvent.ClientId, startOderEvent.Total, startOderEvent.ProductsOrder, startOderEvent.CardName,
					startOderEvent.CardNumber, startOderEvent.Expiration, startOderEvent.Cvv));
			}
			else
			{
				await _mediatorHandler.PublishEvent(new OrderStockRejectedEvent(startOderEvent.OrderId, startOderEvent.ClientId));
			}
		}

		public async Task Handle(OrderProcessCancelEvent orderProcessCancelEvent, CancellationToken cancellationToken)
		{
			await _stockService.PutListProductsOrder(orderProcessCancelEvent.ProductsOrder);
		}
	}
}
