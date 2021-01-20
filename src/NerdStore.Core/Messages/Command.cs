using FluentValidation.Results;
using MediatR;
using System;

namespace NerdStore.Core.Messages
{
	public abstract class Command : Message, IRequest<bool>
	{
		protected Command()
		{
			TimeStamp = DateTime.Now;
		}
		public DateTime TimeStamp { get; private set; }
		public ValidationResult ValidationResult { get; protected set; }

		public virtual bool IsValid()
		{
			throw new NotImplementedException();
		}
	}
}
