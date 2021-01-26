using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Dtos.Cart
{
	public class CartItemDto
	{
		public CartItemDto(Guid productId, string productName, int quantity, decimal unitaryValue, decimal totalValue)
		{
			ProductId = productId;
			ProductName = productName;
			Quantity = quantity;
			UnitaryValue = unitaryValue;
			TotalValue = totalValue;
		}

		public Guid ProductId { get; private set; }
		public string ProductName { get; private set; }
		public int Quantity { get; private set; }
		public decimal UnitaryValue { get; private set; }
		public decimal TotalValue { get; private set; }
	}
}
