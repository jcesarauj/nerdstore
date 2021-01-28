using FluentValidation;
using NerdStore.Sales.Domain.Commands.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Validation.Command.Order
{
	public class ApplyVoucherOrderValidation : AbstractValidator<ApplyVoucherOrderCommand>
	{
		public ApplyVoucherOrderValidation()
		{
			RuleFor(c => c.ClientId)
				.NotEqual(Guid.Empty)
				.WithMessage("Id do cliente inválido");

			RuleFor(c => c.VoucherCode)
				.NotEmpty()
				.WithMessage("O código do voucher não pode ser vazio");
		}
	}
}
