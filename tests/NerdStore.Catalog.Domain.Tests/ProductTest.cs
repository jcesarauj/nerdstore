using System;
using Xunit;
using NerdStore.Core.DomainObjects;
using NerdStore.Catalog.Domain.Models;
using NerdStore.Catalog.Domain.Constants;

namespace NerdStore.Catalog.Domain.Tests
{
	public class ProductTest
	{
		[Fact]
		public void should_return_error_when_trying_to_create_object_with_null_name()
		{
			var ex = Assert.Throws<DomainException>(() => new Product(string.Empty, "Description", true, Guid.NewGuid(), 10, DateTime.Now, "Image"));
			Assert.Equal(ProductConstants.MESSAGE_PRODUCT_NAME_NULL, ex.Message);
		}

		[Fact]
		public void should_return_error_when_trying_to_create_object_with_null_description()
		{
			var ex = Assert.Throws<DomainException>(() => new Product("Name", string.Empty, true, Guid.NewGuid(), 10, DateTime.Now, "Image"));
			Assert.Equal(ProductConstants.MESSAGE_PRODUCT_DESCRIPTION_NULL, ex.Message);
		}
	}
}
