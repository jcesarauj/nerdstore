using FluentValidation;
using NerdStore.Sales.Domain.Commands;
using System;

namespace NerdStore.Sales.Domain.Validation
{
	public class AddOrderItemValidation : AbstractValidator<AddOrderItemCommand>
	{
		public AddOrderItemValidation()
		{
			RuleFor(c => c.ClientId)
				.NotEqual(Guid.Empty)
				.WithMessage("Id do Cliente Inválido");

			RuleFor(c => c.ProductId)
				.NotEqual(Guid.Empty)
				.WithMessage("Id do Produto Inválido");

			RuleFor(c => c.ProductName)
				.NotEmpty()
				.WithMessage("O Nome do Produto não foi informado");

			RuleFor(c => c.Quantity)
				.GreaterThan(0)
				.WithMessage("Quantidade mínima do produto deve ser 1");

			RuleFor(c => c.Quantity)
				.LessThan(15)
				.WithMessage("Quantidade máxima de um item é 15");

			RuleFor(c => c.UnitaryValue)
				.GreaterThan(0)
				.WithMessage("O valor do item deve ser maior que 0");
		}
	}
}
