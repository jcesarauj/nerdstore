using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Domain.Events
{
	public class ProductBelowStockEvent : DomainEvent
	{
		public int RemainingAmount { get; private set; }
		public ProductBelowStockEvent(Guid agregatedId, int remainingAmount) : base(agregatedId)
		{
			RemainingAmount = remainingAmount;
		}
	}
}
