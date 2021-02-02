using NerdStore.Core.Contracts;
using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Payments.Business.Models
{
	public class Payment : Entity, IAggregateRoot
    {
        public Guid OrderId { get; set; }
        public string Status { get; set; }
        public decimal Value { get; set; }

        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }

        // EF. Rel.
        public Transaction Transacao { get; set; }
    }
}
