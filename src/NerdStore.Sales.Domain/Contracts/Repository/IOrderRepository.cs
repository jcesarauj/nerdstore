using NerdStore.Core.Contracts.Data;
using NerdStore.Sales.Domain.Models;
using System;

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
	}
}
