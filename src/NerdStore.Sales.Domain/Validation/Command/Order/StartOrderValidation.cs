using FluentValidation;
using NerdStore.Sales.Domain.Commands.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Sales.Domain.Validation.Command.Order
{
	public class StartOrderValidation : AbstractValidator<StartOrderCommand>
	{
		public StartOrderValidation()
		{
			RuleFor(c => c.ClientId)
					.NotEqual(Guid.Empty)
					.WithMessage("Id do cliente inválido");

			RuleFor(c => c.OrderId)
				.NotEqual(Guid.Empty)
				.WithMessage("Id do pedido inválido");

			RuleFor(c => c.CardName)
				.NotEmpty()
				.WithMessage("O nome no cartão não foi informado");

			RuleFor(c => c.CardNumber)
				.CreditCard()
				.WithMessage("Número de cartão de crédito inválido");

			RuleFor(c => c.Expiration)
				.NotEmpty()
				.WithMessage("Data de expiração não informada");

			RuleFor(c => c.Cvv)
				.Length(3, 4)
				.WithMessage("O CVV não foi preenchido corretamente");
		}
	}
}
