using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Contracts.Service;
using NerdStore.Catalog.Domain.Events;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.DomainObjects.Dtos.Order;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Service
{
	public class StockService : IStockService
	{
		private readonly IProductRepository _productRepository;
		private readonly IMediatorHandler _mediatorHandler;
		public StockService(IProductRepository productRepository, IMediatorHandler mediatorHandler)
		{
			_productRepository = productRepository;
			_mediatorHandler = mediatorHandler;
		}
		public async Task<bool> CreditStock(Guid productId, int quantity)
		{
			var product = await _productRepository.GetById(productId);

			if (product == null) return false;

			if (!product.HasStock(quantity)) return false;

			product.DebitStock(quantity);

			if (product.QuantityInStock < 10)
			{
				await _mediatorHandler.PublishEvent(new ProductBelowStockEvent(product.Id, product.QuantityInStock));
			}

			_productRepository.Update(product);

			return await _productRepository.UnitOfWork.Commit();
		}

		public Task<bool> DebitListProductsOrder(ListProductsOrder list)
		{
			throw new NotImplementedException();
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

		public Task<bool> PutListProductsOrder(ListProductsOrder lista)
		{
			throw new NotImplementedException();
		}

		private async Task<bool> DebitarStockItem(Guid productId, int quantity)
		{
			var product = await _productRepository.GetById(productId);

			if (product == null) return false;

			if (!product.HasStock(quantity))
			{
				await _mediatorHandler.PublishNotification(new DomainNotification("Estoque", $"Produto - {product.Name} sem estoque"));
				return false;
			}

			product.DebitStock(quantity);

			if (product.QuantityInStock < 10)
			{
				await _mediatorHandler.PublishEvent(new ProductBelowStockEvent(product.Id, product.QuantityInStock));
			}

			_productRepository.Update(product);
			return true;
		}


	}
}
