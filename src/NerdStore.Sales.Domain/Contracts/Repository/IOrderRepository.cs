using NerdStore.Core.Contracts.Data;
using NerdStore.Sales.Domain.Models;
using NerdStore.Sales.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using order = NerdStore.Sales.Domain.Models.Order;

namespace NerdStore.Sales.Domain.Contracts.Repository
{
	public interface IOrderRepository : IRepository<order.Order>
	{
		void Add(order.Order order);
		void Update(order.Order order);
		void GetById(int orderId);
		Task<order.Order> GetByClientId(Guid clientId);
		Task<Voucher> GetVoucherByVoucherCode(string voucherCode);
		
		void AddOrderItem(order.Order order);
		void RemoveOrderItem(order.OrderItem order);
		void UpdateOrderItem(order.OrderItem order);
		Task<OrderItem> GetOrderItemById(Guid orderItemId, Guid productId);
		Task<order.OrderItem> GetItemByOrderId(Guid orderItemId, Guid productId);
		Task<order.Order> GetOrderDraftByClientId(Guid clientId);
		Task<IEnumerable<order.Order>> GetOrdersByClientId(Guid clienteId);

		
	}
}
