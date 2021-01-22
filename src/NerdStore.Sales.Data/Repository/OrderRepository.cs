using NerdStore.Core.Contracts.Data;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Models;
using System;

namespace NerdStore.Sales.Data.Repository
{
	public class OrderRepository : IOrderRepository
	{
		public IUnitOfWork UnitOfWork => throw new NotImplementedException();

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
	}
}
