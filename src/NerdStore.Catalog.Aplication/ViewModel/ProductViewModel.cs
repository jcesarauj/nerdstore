using NerdStore.Catalog.Domain.Models;
using System;

namespace NerdStore.Catalog.Application.ViewModel
{
	public class ProductViewModel
	{
		public ProductViewModel(Product product)
		{
			ProductId = product.Id;
			Name = product.Name;
			Description = product.Description;
			Active = product.Active;
			Price = product.Price;
			CreateDate = product.CreateDate;
			Image = product.Image;
			QuantityInStock = product.QuantityInStock;
			CategoryId = product.CategoryId;
		}
		public Guid ProductId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool Active { get; private set; }
		public decimal Price { get; private set; }
		public DateTime CreateDate { get; private set; }
		public string Image { get; private set; }
		public int QuantityInStock { get; private set; }
		public Guid CategoryId { get; private set; }
		public CategoryViewModel Category { get; private set; }
	}
}
