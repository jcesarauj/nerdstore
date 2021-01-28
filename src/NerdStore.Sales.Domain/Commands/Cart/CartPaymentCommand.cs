using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class CartPaymentCommand
	{
		public string CardName { get; set; }
		public string CardNumber { get; set; }
		public string Expiration { get; set; }
		public string Cvv { get; set; }
	}
}
