using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class CartItemCommand
	{
		public Guid ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitaryValue { get; set; }
		public decimal TotalValue { get; set; }
	}
}
