using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Contracts.Mediatr
{
	public interface IMediaTrHandler
	{
		Task PublishEvent<T>(T @event) where T : Event;
	}
}
