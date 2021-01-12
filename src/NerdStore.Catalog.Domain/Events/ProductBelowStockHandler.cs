using MediatR;
using NerdStore.Catalog.Domain.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Events
{
	public class ProductBelowStockHandler : INotificationHandler<ProductBelowStockEvent>
	{
		private readonly IProductRepository _productRepository;

		public ProductBelowStockHandler(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public async Task Handle(ProductBelowStockEvent message, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetById(message.AgregatedId);
			
			//send email to buing more products
		}
	}
}
