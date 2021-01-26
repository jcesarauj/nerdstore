using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Dtos.Order
{
	public class OrderDto
	{
		public OrderDto(Guid oderId, int code, decimal totalValue, DateTime insertDate, int orderStatus)
		{
			OderId = oderId;
			Code = code;
			TotalValue = totalValue;
			InsertDate = insertDate;
			OrderStatus = orderStatus;
		}

		public Guid OderId { get; private set; }
		public int Code { get; private set; }
		public decimal TotalValue { get; private set; }
		public DateTime InsertDate { get; private set; }
		public int OrderStatus { get; private set; }
	}
}
