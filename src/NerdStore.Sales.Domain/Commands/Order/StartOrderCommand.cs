using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation.Command.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NerdStore.Sales.Domain.Commands.Order
{
	public class StartOrderCommand : Command
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }
		public decimal Total { get; private set; }
		public string CardName { get; private set; }
		public string CardNumber { get; private set; }
		public string Expiration { get; private set; }
		public string Cvv { get; private set; }

		public StartOrderCommand(Guid orderId, Guid clientId, decimal total, string cardName, string cardNumber, string expiration, string cvv)
		{
			OrderId = orderId;
			ClientId = clientId;
			Total = total;
			CardName = cardName;
			CardNumber = cardNumber;
			Expiration = expiration;
			Cvv = cvv;
		}

		public override bool IsValid()
		{
			ValidationResult = new StartOrderValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
