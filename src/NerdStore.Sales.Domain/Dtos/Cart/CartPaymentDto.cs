using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Dtos.Cart
{
	public class CartPaymentDto
	{
		public string CardName { get; set; }
		public string CardNumber { get; set; }
		public string Expiration { get; set; }
		public string CvvCard { get; set; }
	}
}
