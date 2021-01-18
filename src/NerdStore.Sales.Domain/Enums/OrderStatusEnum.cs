using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Sales.Domain.Enums
{
	public enum OrderStatusEnum
	{
		Draft = 0,
		Initiated = 1,
		Paid = 2,
		Delivered = 3,
		Canceled = 4
	}
}
