using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Contracts.Service;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Core.Contracts.Mediatr;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Service
{
	public class StockService : IStockService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMediaTrHandler _mediaTrHandler;
		public StockService(IProductRepository productRepository, IMediaTrHandler mediaTrHandler)
		{
			_productRepository = productRepository;
			_mediaTrHandler = mediaTrHandler;
		}
		public async Task<bool> CreditStock(Guid productId, int quantity)
		{
			var product = await _productRepository.GetById(productId);

			if (product == null) return false;

			if (!product.HasStock(quantity)) return false;

			product.DebitStock(quantity);

			if (product.QuantityInStock < 10)
			{
				await _mediaTrHandler.PublishEvent(new ProductBelowStockEvent(product.Id, product.QuantityInStock));
			}

			_productRepository.Update(product);

			return await _productRepository.UnitOfWork.Commit();
		}

		public async Task<bool> DebitStock(Guid productId, int quantity)
		{
			var product = await _productRepository.GetById(productId);

			if (product == null) return false;

			if (!product.HasStock(quantity)) return false;

			product.CreditStock(quantity);

			_productRepository.Update(product);

			return await _productRepository.UnitOfWork.Commit();
		}


	}
}
