using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Data;
using NerdStore.Core.Contracts.Data;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Models;
using NerdStore.Sales.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data.Repository
{
	public class OrderRepository : IOrderRepository
	{
		public IUnitOfWork UnitOfWork => throw new NotImplementedException();

		private readonly SalesContext _context;

		public OrderRepository(SalesContext context)
		{
			_context = context;
		}

		public void AddOrder(Order order)
		{
			throw new NotImplementedException();
		}

		public void AddOrderItem(Order order)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public Order GetOrderByClientId(Guid clientId)
		{
			throw new NotImplementedException();
		}

		public void GetOrderById(int orderId)
		{
			throw new NotImplementedException();
		}

		public void GetOrderItemById(int orderItemId)
		{
			throw new NotImplementedException();
		}

		public void UpdateOrder(Order order)
		{
			throw new NotImplementedException();
		}

		public void UpdateOrderItem(Order order)
		{
			throw new NotImplementedException();
		}

		public async Task<Order> GetOrderDraftByClientId(Guid clientId)
		{
			var order = await _context.Orders.FirstOrDefaultAsync(p => p.ClientId == clientId && p.OrderStatus == Domain.Enums.OrderStatusEnum.Draft);
			if (order == null) return null;

			await _context.Entry(order)
				.Collection(i => i.OrderItems).LoadAsync();

			if (order.VoucherId != null)
			{
				await _context.Entry(order)
					.Reference(i => i.Voucher).LoadAsync();
			}

			return order;
		}		

		public Task<Voucher> GetVoucherByVoucherCode(string voucherCode)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Order>> GetOrdersByClientId(Guid clienteId)
		{
			throw new NotImplementedException();
		}

		public void Add(Order order)
		{
			throw new NotImplementedException();
		}

		public void Update(Order order)
		{
			throw new NotImplementedException();
		}

		public void GetById(int orderId)
		{
			throw new NotImplementedException();
		}

		public Task<Order> GetByClientId(Guid clientId)
		{
			throw new NotImplementedException();
		}

		public void RemoveOrderItem(OrderItem order)
		{
			throw new NotImplementedException();
		}

		public void UpdateOrderItem(OrderItem order)
		{
			throw new NotImplementedException();
		}

		public Task<OrderItem> GetOrderItemById(Guid orderItemId, Guid productId)
		{
			throw new NotImplementedException();
		}

		public Task<OrderItem> GetItemByOrderId(Guid orderItemId, Guid productId)
		{
			throw new NotImplementedException();
		}

		public Task<Order> GetById(Guid orderId)
		{
			throw new NotImplementedException();
		}
	}
}
