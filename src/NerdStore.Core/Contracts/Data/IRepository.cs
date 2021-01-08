using System;

namespace NerdStore.Core.Contracts.Data
{
	public interface IRepository<T> : IDisposable where T : IAggregateRoot
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
