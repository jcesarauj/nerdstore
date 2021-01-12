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
	public class MediaTrHandler : IMediaTrHandler
	{
		private readonly IMediator _mediator;
		public MediaTrHandler(IMediator mediator)
		{
			_mediator = mediator;
		}
		public async Task PublishEvent<T>(T @event) where T : Event
		{
			await _mediator.Publish(@event);
		}
	}
}
