using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Sales.Domain.Models.Order
{
	public class OrderItem : Entity
	{
		protected OrderItem() { }

		public OrderItem(Guid productId, string productName, int quantity, decimal unitaryValue)
		{
			ProductId = productId;
			ProductName = productName;
			Quantity = quantity;
			UnitaryValue = unitaryValue;
		}

		public Guid OrderItemId { get; private set; }
		public Guid OrderId { get; private set; }
		public Guid ProductId { get; private set; }
		public string ProductName { get; private set; }
		public int Quantity { get; private set; }
		public decimal UnitaryValue { get; private set; }
		public virtual Order Order { get; private set; }

		public decimal CalculateValue() => Quantity * UnitaryValue;

		public decimal AddQuantity(int quantity) => Quantity += quantity;

		public decimal UpdateQuantity(int quantity) => Quantity = quantity;

	}
}
