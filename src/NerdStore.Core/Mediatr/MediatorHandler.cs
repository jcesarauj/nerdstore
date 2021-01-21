using MediatR;
using NerdStore.Core.Contracts.Mediatr;
using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Mediatr
{
	public class MediatorHandler : IMediatorHandler
	{
		private readonly IMediator _mediator;
		public MediatorHandler(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task PublishEvent<T>(T @event) where T : Event
		{
			await _mediator.Publish(@event);
		}

		public async Task<bool> SendCommand<T>(T command) where T : Command
		{
			var result = await _mediator.Send(command);
			return result;
		}
	}
}
