using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class CartCommand
	{
        public Guid OrderId { get; set; }
        public Guid ClientId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalValue { get; set; }
        public decimal DiscountValue { get; set; }
        public string VoucherCode { get; set; }

        public List<CartItemCommand> Items { get; set; } = new List<CartItemCommand>();
        public CartPaymentCommand Payment { get; set; }
    }
}
