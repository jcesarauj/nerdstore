using NerdStore.Core.Contracts.Data;
using NerdStore.Sales.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Contracts.Repository
{
	public interface IOrderRepository : IRepository<Order>
	{
		void AddOrder(Order order);
		void UpdateOrder(Order order);
		void GetOrderById(int orderId);
		Order GetOrderByClientId(Guid clientId);

		void AddOrderItem(Order order);
		void UpdateOrderItem(Order order);
		void GetOrderItemById(int orderItemId);
		Task<Order> GetOrderDraftByClientId(Guid clientId);

		Task<IEnumerable<Order>> GetOrdersByClientId(Guid clienteId);
	}
}
