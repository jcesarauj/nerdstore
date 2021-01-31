using NerdStore.Core.DomainObjects.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Contracts.Service
{
	public interface IStockService
	{
		Task<bool> CreditStock(Guid productId, int quantity);

		Task<bool> DebitStock(Guid productId, int quantity);

		Task<bool> DebitListProductsOrder(ListProductsOrder list);
		Task<bool> PutListProductsOrder(ListProductsOrder lista);
	}
}
