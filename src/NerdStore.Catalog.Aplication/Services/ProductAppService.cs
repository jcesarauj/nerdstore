using NerdStore.Catalog.Application.Contract;
using NerdStore.Catalog.Application.ViewModel;
using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Application.Services
{
	public class ProductAppService : IProductAppService
	{
		private readonly IProductRepository _productRepository;

		public ProductAppService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public void Add(ProductViewModel productViewModel)
		{
			Product product = new(productViewModel.Name, productViewModel.Description, productViewModel.Active, productViewModel.CategoryId, productViewModel.Price, productViewModel.CreateDate, productViewModel.Image, null);
			_productRepository.Add(product);
			_productRepository.UnitOfWork.Commit();
		}

		public void Delete(Guid productId)
		{
			throw new NotImplementedException();
		}

		public async Task<ProductViewModel> GetById(Guid productId)
		{
			var product = await _productRepository.GetById(productId);
			var productViewModel = (product != null ? new ProductViewModel(product) : null);
			return productViewModel;
		}

		public Task<IEnumerable<ProductViewModel>> List()
		{
			throw new NotImplementedException();
		}

		public void Update(ProductViewModel productViewModel)
		{
			Product product = new(productViewModel.Name, productViewModel.Description, productViewModel.Active, productViewModel.CategoryId, productViewModel.Price, productViewModel.CreateDate, productViewModel.Image, null);
			_productRepository.Update(product);
			_productRepository.UnitOfWork.Commit();
		}
	}
}
