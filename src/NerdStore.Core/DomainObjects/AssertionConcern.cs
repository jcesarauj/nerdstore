using System;

namespace NerdStore.Core.DomainObjects
{
	public static class AssertionConcern
	{
		public static void ValidateIfIsEmpty(string value, string message)
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new DomainException(message);
			}
		}
		public static void ValidateIfNull(object value, string message)
		{
			if (value == null)
			{
				throw new DomainException(message);
			}
		}

		public static void ValidateIfEqual(object value, object value2, string message)
		{
			if (value == value2)
			{
				throw new DomainException(message);
			}
		}
	}
}
