using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages
{
	public abstract class Message
	{
		protected Message()
		{
			MessageType = GetType().Name;
		}
		public string MessageType { get; protected set; }
		public Guid AgregatedId { get; protected set; }
	}
}
