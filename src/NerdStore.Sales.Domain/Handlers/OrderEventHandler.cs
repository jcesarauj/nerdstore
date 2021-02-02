using MediatR;
using NerdStore.Catalog.Domain.Contracts.Service;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;
using NerdStore.Sales.Domain.Commands.Order;
using NerdStore.Sales.Domain.Events.Order;
using NerdStore.Vendas.Application.Commands;
using System.Threading;
using System.Threading.Tasks;


namespace NerdStore.Sales.Domain.Handlers
{
	public class OrderEventHandler :
		INotificationHandler<DraftOrderStartedEvent>,
		INotificationHandler<OrderItemAddedEvent>,
		INotificationHandler<OrderItemUpdatedEvent>,
		INotificationHandler<OrderStockRejectedEvent>,
		INotificationHandler<OrderPaymentRealizedEvent>,
		INotificationHandler<OrderPaymentRefusedEvent>
	{

		private readonly IMediatorHandler _mediatorHandler;
		private readonly IStockService _stockService;

		public OrderEventHandler(IMediatorHandler mediatorHandler, IStockService stockService)
		{
			_mediatorHandler = mediatorHandler;
			_stockService = stockService;
		}

		public Task Handle(DraftOrderStartedEvent draftOrderStartedEvent, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		public Task Handle(OrderItemAddedEvent orderItemAddedEvent, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		public Task Handle(OrderItemUpdatedEvent orderItemUpdatedEvent, CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}

		public async Task Handle(OrderStockRejectedEvent orderStockRejectedEvent, CancellationToken cancellationToken)
		{
			await _mediatorHandler.SendCommand(new CancelProcessOrderCommand(orderStockRejectedEvent.OrderId, orderStockRejectedEvent.ClientId));
		}

		public async Task Handle(OrderPaymentRealizedEvent orderPaymentRealizedEvent, CancellationToken cancellationToken)
		{
			await _mediatorHandler.SendCommand(new FinalizeOrderCommand(orderPaymentRealizedEvent.OrderId, orderPaymentRealizedEvent.ClientId));
		}

		public async Task Handle(OrderPaymentRefusedEvent orderPaymentRefusedEvent, CancellationToken cancellationToken)
		{
			await _mediatorHandler.SendCommand(new CancelProcessOrderReverseStockCommand(orderPaymentRefusedEvent.OrderId, orderPaymentRefusedEvent.ClientId));
		}
	}
}
