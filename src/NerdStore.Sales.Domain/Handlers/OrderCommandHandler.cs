using MediatR;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Sales.Domain.Commands.Order;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Events.Order;
using NerdStore.Sales.Domain.Models.Order;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Handlers
{
	public class OrderCommandHandler : IRequestHandler<AddOrderItemCommand, bool>,
		 IRequestHandler<ApplyVoucherOrderCommand, bool>,
		IRequestHandler<RemoveItemOrderCommand, bool>,
		IRequestHandler<UpdateItemOrderCommand, bool>,
		IRequestHandler<StartOrderCommand, bool>,
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

			var findOrder = _orderRepository.GetByClientId(addOrderItemCommand.ClientId);

			OrderItem orderItem = new(addOrderItemCommand.ProductId, addOrderItemCommand.ProductName, addOrderItemCommand.Quantity, addOrderItemCommand.UnitaryValue);
			Order order = new(addOrderItemCommand.ClientId);

			if (findOrder == null)
			{
				order.AddItem(orderItem);
				_orderRepository.Add(order);
				order.AddEvent(new DraftOrderStartedEvent(addOrderItemCommand.ClientId, order.Id));
			}
			else
			{
				if (order.VerifyIfItemExist(orderItem))
				{
					order.UpdateOrderITem(orderItem);
					_orderRepository.UpdateOrderItem(orderItem);
				}

				order.AddEvent(new OrderItemUpdatedEvent(addOrderItemCommand.ClientId, order.Id, order.TotalValue));
			}

			order.AddEvent(new OrderItemAddedEvent(addOrderItemCommand.ClientId, order.Id, addOrderItemCommand.ProductId,
						addOrderItemCommand.UnitaryValue, addOrderItemCommand.Quantity));

			return await _orderRepository.UnitOfWork.Commit();
		}

		public async Task<bool> Handle(ApplyVoucherOrderCommand applyVoucherOrderCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(applyVoucherOrderCommand)) return false;

			var order = await _orderRepository.GetOrderDraftByClientId(applyVoucherOrderCommand.ClientId);

			if (order == null)
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Pedido não encontrado!"));
				return false;
			}

			var voucher = await _orderRepository.GetVoucherByVoucherCode(applyVoucherOrderCommand.VoucherCode);

			if (voucher == null)
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Voucher não encontrado!"));
				return false;
			}

			var voucherApplyedValidation = order.ApplyVoucher(voucher);
			if (!voucherApplyedValidation.IsValid)
			{
				foreach (var error in voucherApplyedValidation.Errors)
				{
					await _mediatorHandler.PublishNotification(new DomainNotification(error.ErrorCode, error.ErrorMessage));
				}

				return false;
			}

			order.AddEvent(new VoucherAppliedEvent(applyVoucherOrderCommand.ClientId, order.Id, voucher.Id));

			_orderRepository.Update(order);

			return await _orderRepository.UnitOfWork.Commit();
		}

		public async Task<bool> Handle(RemoveItemOrderCommand removeItemOrderCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(removeItemOrderCommand)) return false;

			var order = await _orderRepository.GetOrderDraftByClientId(removeItemOrderCommand.ClientId);

			if (order == null)
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Pedido não encontrado!"));
				return false;
			}

			var orderItem = await _orderRepository.GetItemByOrderId(order.Id, removeItemOrderCommand.ProductId);

			if (orderItem != null && !order.OrderItemExist(orderItem))
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Item do pedido não encontrado!"));
				return false;
			}

			order.RemoveItem(orderItem);
			order.AddEvent(new OrderProductRemovedEvent(removeItemOrderCommand.ClientId, order.Id, removeItemOrderCommand.ProductId));

			_orderRepository.RemoveOrderItem(orderItem);
			_orderRepository.Update(order);

			return await _orderRepository.UnitOfWork.Commit();
		}

		public async Task<bool> Handle(UpdateItemOrderCommand updateItemOrderCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(updateItemOrderCommand)) return false;

			var order = await _orderRepository.GetOrderDraftByClientId(updateItemOrderCommand.ClientId);

			if (order == null)
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Pedido não encontrado!"));
				return false;
			}

			var orderItem = await _orderRepository.GetOrderItemById(order.Id, updateItemOrderCommand.ProductId);

			if (!order.OrderItemExist(orderItem))
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("pedido", "Item do pedido não encontrado!"));
				return false;
			}

			order.UpdateUnits(orderItem, updateItemOrderCommand.Quantity);
			order.AddEvent(new OrderProductUpdatedEvent(updateItemOrderCommand.ClientId, order.Id, updateItemOrderCommand.ProductId, updateItemOrderCommand.Quantity));

			_orderRepository.UpdateOrderItem(orderItem);
			_orderRepository.Update(order);

			return await _orderRepository.UnitOfWork.Commit();
		}

		public async Task<bool> Handle(StartOrderCommand startOrderCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(startOrderCommand)) return false;

			var order = await _orderRepository.GetOrderDraftByClientId(startOrderCommand.ClientId);
			order.UpdateStatus(Enums.OrderStatusEnum.Started);

			var itensList = new List<Item>();
			order.OrderItems.ForEach(i => itensList.Add(new Item { Id = i.ProdutoId, Quantidade = i.Quantidade }));
			var listaProdutosPedido = new ListaProdutosPedido { PedidoId = order.Id, Itens = itensList };

			order.AddEvent(new StartOrderEvent(order.Id, order.ClientId, listaProdutosPedido, order.TotalValue, startOrderCommand.CardName, startOrderCommand.CardNumber, startOrderCommand.Expiration, startOrderCommand.Cvv));

			_orderRepository.Update(order);
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
