using MediatR;
using NerdStore.Core.Messages;
using NerdStore.Sales.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Sales.Api.Handlers
{
	public class OrderCommandHandler : IRequestHandler<AddOrderItemCommand, bool>
	{
		public async Task<bool> Handle(AddOrderItemCommand addOrderItemCommand, CancellationToken cancellationToken)
		{
			if (!ValidateCommand(addOrderItemCommand)) return false;

			throw new NotImplementedException();
		}

		private bool ValidateCommand(Command command)
		{
			if (command.IsValid()) return true;

			foreach (var error in command.ValidationResult.Errors)
			{
				//send error event
			}

			return false;
		}
	}
}
