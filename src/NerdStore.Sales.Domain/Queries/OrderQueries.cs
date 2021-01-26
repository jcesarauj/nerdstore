using NerdStore.Sales.Domain.Contracts.Queries;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Dtos.Cart;
using NerdStore.Sales.Domain.Dtos.Order;
using NerdStore.Sales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Queries
{
	public class OrderQueries : IOrderQueries
	{
		private readonly IOrderRepository _orderRepository;

		public OrderQueries(IOrderRepository orderRepository)
		{
			_orderRepository = orderRepository;
		}

		public async Task<CartDto> GetCartClient(Guid clientId)
		{
			var order = await _orderRepository.GetOrderDraftByClientId(clientId);
			if (order == null) return null;

			CartDto carrinho = new(order.ClientId, order.TotalValue, order.Id, order.Discount, order.Discount + order.TotalValue, order.Voucher.Code);

			foreach (var item in order.OrderItems)
			{
				carrinho.Items.Add(new CartItemDto(item.ProductId, item.ProductName, item.Quantity, item.UnitaryValue, item.UnitaryValue * item.Quantity));
			}

			return carrinho;
		}

		public async Task<IEnumerable<OrderDto>> GetOrderClient(Guid clientId)
		{
			var orders = await _orderRepository.GetOrdersByClientId(clientId);

			orders = orders.Where(p => p.OrderStatus == OrderStatusEnum.Paid || p.OrderStatus == OrderStatusEnum.Canceled)
				.OrderByDescending(p => p.Code);

			if (!orders.Any()) return null;

			var pedidosView = new List<OrderDto>();

			foreach (var order in orders)
			{
				pedidosView.Add(new OrderDto(order.Id, order.Code, order.TotalValue, order.CreateDate, (int)order.OrderStatus));
			}

			return pedidosView;
		}
	}
}
