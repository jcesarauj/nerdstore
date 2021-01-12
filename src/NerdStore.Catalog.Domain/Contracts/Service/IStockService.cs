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
	}
}
