using MediatR;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Sales.Domain.Commands;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Handlers
{
	public class OrderCommandHandler : IRequestHandler<AddOrderItemCommand, bool>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMediatorHandler _mediatorHandler;
		public OrderCommandHandler(IOrderRepository orderRepository, IMediatorHandler mediatorHandler)
		{
			_orderRepository = orderRepository;
			_mediatorHandler = mediatorHandler;
		}
		public async Task<bool> Handle(AddOrderItemCommand addOrderItemCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(addOrderItemCommand)) return false;

			var findOrder = _orderRepository.GetOrderByClientId(addOrderItemCommand.ClientId);

			OrderItem orderItem = new(addOrderItemCommand.ProductId, addOrderItemCommand.ProductName, addOrderItemCommand.Quantity, addOrderItemCommand.UnitaryValue);
			Order order = new(addOrderItemCommand.ClientId);

			if (findOrder == null)
			{
				order.AddItem(orderItem);
				_orderRepository.AddOrder(order);
			}
			else
			{
				if (order.VerifyIfItemExist(orderItem))
				{
					order.UpdateOrderITem(orderItem);
					_orderRepository.UpdateOrderItem(order);
				}
			}

			return await _orderRepository.UnitOfWork.Commit();
		}
		private bool ValidateCommand(Command command)
		{
			if (command.IsValid()) return true;

			foreach (var error in command.ValidationResult.Errors) _mediatorHandler.PublishNotification(new DomainNotification(command.MessageType, error.ErrorMessage));

			return false;
		}
	}
}
