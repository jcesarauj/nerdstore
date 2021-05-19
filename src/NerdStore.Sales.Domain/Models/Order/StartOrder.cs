using NerdStore.Core.DomainObjects.Dtos.Order;
using NerdStore.Core.Extensions;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents.Order;
using NerdStore.Sales.Domain.Commands.Order;
using NerdStore.Sales.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Models.Order
{
	public class StartOrder
	{
		private Order _order;
		private StartOrderCommand _startOrderCommand;
		private IOrderRepository _orderRepository;
		private Guid _clientId;

		public StartOrder(StartOrderCommand startOrderCommand, IOrderRepository orderRepository)
		{
			_startOrderCommand = startOrderCommand;
			_orderRepository = orderRepository;
		}

		public StartOrder GetOrderDraftByClientId()
		{
			_order = _orderRepository.GetOrderDraftByClientId(_startOrderCommand.ClientId).Result;
			return this;
		}

		public StartOrder SetStatusStartInOrder()
		{
			_order.Start();
			return this;
		}

		public StartOrder AddEvent()
		{
			var itensList = new List<Item>();

			_order.OrderItems.ForEach(i => itensList.Add(new Item { Id = i.ProductId, Quantity = i.Quantity }));

			var listProductOrder = new ListProductsOrder { OrderId = _order.Id, Itens = itensList };

			_order.AddEvent(new StartOderEvent(_order.Id, _order.ClientId, _order.TotalValue,
				listProductOrder, _startOrderCommand.CardName, _startOrderCommand.CardNumber,
				_startOrderCommand.Expiration, _startOrderCommand.Cvv));

			return this;
		}

		public async Task<bool> SaveOrder()
		{
			_orderRepository.Update(_order);
			return await _orderRepository.UnitOfWork.Commit();
		}

	}
}
