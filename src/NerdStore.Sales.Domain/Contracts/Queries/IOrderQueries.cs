using NerdStore.Sales.Domain.Dtos.Cart;
using NerdStore.Sales.Domain.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Contracts.Queries
{
	public interface IOrderQueries
	{
		Task<CartDto> GetCartClient(Guid clientId);
		Task<IEnumerable<OrderDto>> GetOrderClient(Guid clientId);
	}
}
