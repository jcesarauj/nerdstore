using NerdStore.Core.Messages;

namespace NerdStore.Sales.Domain.Commands.Cart
{
	public class VoucherCommand : Command
	{
		public string VoucherCode { get;  set; }

		public bool IsValid()
		{
			return true;
		}
	}
}
