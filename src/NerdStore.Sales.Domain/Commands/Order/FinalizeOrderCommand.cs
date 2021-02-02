using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Order
{
	public class FinalizeOrderCommand : Command
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }

		public FinalizeOrderCommand(Guid orderId, Guid clientId)
		{
			OrderId = orderId;
			ClientId = clientId;
		}
	}
}
