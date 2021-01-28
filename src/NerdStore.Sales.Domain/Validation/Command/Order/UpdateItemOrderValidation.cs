using FluentValidation;
using NerdStore.Sales.Domain.Commands.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Validation.Command.Order
{
	public class UpdateItemOrderValidation : AbstractValidator<UpdateItemOrderCommand>
	{
		public UpdateItemOrderValidation()
		{
			RuleFor(c => c.ClientId)
					.NotEqual(Guid.Empty)
					.WithMessage("Id do cliente inválido");


			RuleFor(c => c.ProductId)
					.NotEqual(Guid.Empty)
					.WithMessage("Id do produto inválido");

			RuleFor(c => c.Quantity)
					.GreaterThan(0)
					.WithMessage("A quantidade miníma de um item é 1");

			RuleFor(c => c.Quantity)
					.LessThan(15)
					.WithMessage("A quantidade máxima de um item é 15");
		}
	}
}
