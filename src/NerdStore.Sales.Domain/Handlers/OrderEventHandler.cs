using MediatR;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Sales.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Handlers
{
	public class OrderEventHandler :
		INotificationHandler<DraftOrderStartedEvent>,
		INotificationHandler<OrderItemAddedEvent>,
		INotificationHandler<OrderItemUpdatedEvent>
	{

		private readonly IMediatorHandler _mediatorHandler;

		public OrderEventHandler(IMediatorHandler mediatorHandler)
		{
			_mediatorHandler = mediatorHandler;
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
	}
}
