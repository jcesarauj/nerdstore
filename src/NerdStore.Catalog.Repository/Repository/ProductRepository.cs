using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Models;
using NerdStore.Core.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly CatalogContext _catalogContext;

		public ProductRepository(CatalogContext catalogContext)
		{
			_catalogContext = catalogContext;
		}

		public IUnitOfWork UnitOfWork => _catalogContext;

		public void Add(Product product)
		{
			_catalogContext.Products.Add(product);
		}

		public void Delete(Guid productId)
		{
			throw new System.NotImplementedException();
		}

		public async Task<Product> GetById(Guid productId)
		{
			var product = await _catalogContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);
			return product;
		}

		public async Task<IEnumerable<Product>> List()
		{
			return await _catalogContext.Products.AsNoTracking().ToListAsync();
		}

		public void Update(Product product)
		{
			_catalogContext.Products.Update(product);
		}

		public void Add(Category category)
		{
			_catalogContext.Categories.Add(category);
		}

		public void Update(Category category)
		{
			_catalogContext.Categories.Update(category);
		}

		public void Dispose()
		{
			_catalogContext.Dispose();
		}

	}
}
