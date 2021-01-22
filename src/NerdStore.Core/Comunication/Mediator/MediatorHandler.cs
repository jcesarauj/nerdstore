using MediatR;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System.Threading.Tasks;

namespace NerdStore.Core.Comunication.Mediator
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

		public async Task PublishNotification<T>(T notification) where T : DomainNotification
		{
			await _mediator.Publish(notification);
		}

		public async Task<bool> SendCommand<T>(T command) where T : Command
		{
			var result = await _mediator.Send(command);
			return result;
		}
	}
}
