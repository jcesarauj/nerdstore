using NerdStore.Core.Messages;
using System;
using System.Collections.Generic;

namespace NerdStore.Core.DomainObjects
{
	public abstract class Entity
	{
		private List<Event> _notifications;

		public Guid Id { get; set; }
		public DateTime CreateDate { get; private set; }
		public DateTime UpdateDate { get; private set; }
		protected bool Active { get; set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
		}


		public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

		public void AddEvent(Event @event)
		{
			_notifications = _notifications ?? new List<Event>();
			_notifications.Add(@event);
		}

		public void RemoveEvent(Event @event)
		{
			_notifications?.Remove(@event);
		}

		public void ClearEvents()
		{
			_notifications?.Clear();
		}
	}
}
