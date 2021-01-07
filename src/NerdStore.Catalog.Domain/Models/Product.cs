using NerdStore.Catalog.Domain.Constants;
using NerdStore.Core.Contracts;
using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalog.Domain.Models
{
	public class Product : Entity, IAggregateRoot
	{
		public Product(string name, string description, bool active, Guid categoryId, decimal price, DateTime createDate, string image)
		{
			Name = name;
			Description = description;
			Active = active;
			Price = price;
			CreateDate = createDate;
			Image = image;
			CategoryId = categoryId;

			Validate();
		}

		public string Name { get; private set; }
		public string Description { get; private set; }
		public bool Active { get; private set; }
		public decimal Price { get; private set; }
		public DateTime CreateDate { get; private set; }
		public string Image { get; private set; }
		public int QuantityInStock { get; private set; }
		public Guid CategoryId { get; private set; }
		public Category Category { get; private set; }

		public void Activate() => Active = true;
		public void Inactivate() => Active = false;

		public void UpdateCategory(Category category)
		{
			Category = category;
			CategoryId = category.Id;
		}

		public void Validate()
		{
			AssertionConcern.ValidateIfIsEmpty(Name, ProductConstants.MESSAGE_PRODUCT_NAME_NULL);
			AssertionConcern.ValidateIfIsEmpty(Description, ProductConstants.MESSAGE_PRODUCT_DESCRIPTION_NULL);
			AssertionConcern.ValidateIfIsEmpty(Image, ProductConstants.MESSAGE_PRODUCT_IMAGE_NULL);			
		}
	}
}
