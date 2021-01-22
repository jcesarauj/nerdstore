using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Contracts.Mediator
{
	public interface IMediatorHandler
	{
		Task PublishEvent<T>(T @event) where T : Event;
		Task<bool> SendCommand<T>(T command) where T : Command;
		Task PublishNotification<T>(T notification) where T : DomainNotification;
	}
}
