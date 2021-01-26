using NerdStore.Catalog.Data;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Data
{
	public static class MediatorExtension
	{
		public static async Task PublishEvents(this IMediatorHandler mediator, SalesContext ctx)
		{
			var domainEntities = ctx.ChangeTracker
				.Entries<Entity>()
				.Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

			var domainEvents = domainEntities
				.SelectMany(x => x.Entity.Notifications)
				.ToList();

			domainEntities.ToList()
				.ForEach(entity => entity.Entity.ClearEvents());

			var tasks = domainEvents
				.Select(async (domainEvent) =>
				{
					await mediator.PublishEvent(domainEvent);
				});

			await Task.WhenAll(tasks);
		}
	}
}
