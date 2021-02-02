using System;
using NerdStore.Core.Messages;

namespace NerdStore.Vendas.Application.Commands
{
	public class CancelProcessOrderReverseStockCommand : Command
	{
		public Guid OrderId { get; private set; }
		public Guid ClientId { get; private set; }

		public CancelProcessOrderReverseStockCommand(Guid orderId, Guid clientId)
		{
			AgregatedId = orderId;
			OrderId = orderId;
			ClientId = clientId;
		}
	}
}