using System;

namespace NerdStore.Core.DomainObjects
{
	public abstract class Entity
	{
		public Guid Id { get; set; }

		protected Entity()
		{
			Id = Guid.NewGuid();
		}

		protected DateTime CreateDate { get; set; }
		protected DateTime UpdateDate { get; set; }
		protected bool Active { get; set; }
	}
}
