using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Validation.Command.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Commands.Order
{
	public class ApplyVoucherOrderCommand : Command
	{
		public Guid ClientId { get; private set; }
		public string VoucherCode { get; private set; }

		public ApplyVoucherOrderCommand(Guid clientId, string voucherCode)
		{
			ClientId = clientId;
			VoucherCode = voucherCode;
		}

		public override bool IsValid()
		{
			ValidationResult = new ApplyVoucherOrderValidation().Validate(this);
			return ValidationResult.IsValid;
		}
	}
}
