using MediatR;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NerdStore.Core.Comunication.Handler
{
	public class DomainNotificationHandler : INotificationHandler<DomainNotification>
	{
		private List<DomainNotification> _notifications;

		public DomainNotificationHandler()
		{
			_notifications = new List<DomainNotification>();
		}

		public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
		{
			_notifications.Add(notification);
			return Task.CompletedTask;
		}

		public virtual List<DomainNotification> GetNotifications()
		{
			return _notifications;
		}

		public virtual bool HasNotifications()
		{
			return GetNotifications().Any();
		}

		public virtual void Dispose()
		{
			_notifications = new List<DomainNotification>();
		}
	}
}
