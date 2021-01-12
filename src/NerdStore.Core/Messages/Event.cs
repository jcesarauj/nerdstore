using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages
{
	public abstract class Event : Message, INotification
	{
		protected Event()
		{
			TimeStamp = DateTime.Now;
		}
		public DateTime TimeStamp { get; private set; }
	}
}
