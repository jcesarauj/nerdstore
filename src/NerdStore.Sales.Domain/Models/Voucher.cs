using NerdStore.Core.DomainObjects;
using NerdStore.Sales.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Sales.Domain.Models
{
	public class Voucher : Entity
	{
		protected Voucher() { }
		public int VoucherId { get; private set; }
		public string Code { get; private set; }
		public decimal? Percent { get; private set; }
		public decimal? Value { get; private set; }
		public int Quantity { get; private set; }
		public VoucherDiscountTypeEnum VoucherDiscountType { get; private set; }
		public DateTime UtilizedDate { get; private set; }
		public DateTime ValidDate { get; private set; }
		public DateTime IsUtilized { get; private set; }

		public virtual ICollection<Order> Orders { get; private set; }
	}
}
