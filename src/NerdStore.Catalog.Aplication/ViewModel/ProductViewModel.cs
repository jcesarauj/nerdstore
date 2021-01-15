using System;

namespace NerdStore.Catalog.Application.ViewModel
{
	public class ProductViewModel
	{
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
