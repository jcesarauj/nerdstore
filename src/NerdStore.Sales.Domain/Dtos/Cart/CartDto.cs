using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Dtos.Cart
{
	public class CartDto
	{
		public CartDto(Guid clientId, decimal totalValue, Guid orderId, decimal discontValue, decimal subTotal, string voucherCode)
		{
			OrderId = orderId;
			ClientId = clientId;
			SubTotal = subTotal;
			TotalValue = totalValue;
			DiscontValue = discontValue;
			VoucherCode = voucherCode;
		}

		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }
		public decimal SubTotal { get; private set; }
		public decimal TotalValue { get; private set; }
		public decimal DiscontValue { get; private set; }
		public string VoucherCode { get; private set; }

		public List<CartItemDto> Items { get; private set; } = new List<CartItemDto>();
		public CartPaymentDto Pagamento { get; private set; }
	}
}
