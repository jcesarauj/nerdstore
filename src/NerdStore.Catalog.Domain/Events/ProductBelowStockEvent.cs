using NerdStore.Core.Messages.CommonMessages.DomainEvents;
using System;

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
