using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Contracts.Mediatr
{
	public interface IMediatorHandler
	{
		Task PublishEvent<T>(T @event) where T : Event;
		Task<bool> SendCommand<T>(T command) where T : Command;
	}
}
