using NerdStore.Catalog.Domain.Models;
using NerdStore.Core.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Contracts.Repository
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<IEnumerable<Product>> List();
		Task<Product> GetById(Guid productId);
		void Add(Product product);
		void Update(Product product);
		void Delete(Guid productId);

		void Add(Category product);
		void Update(Category product);
	}
}
