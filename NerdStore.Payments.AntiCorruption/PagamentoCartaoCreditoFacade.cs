using NerdStore.Payments.Business.Contracts;
using NerdStore.Payments.Business.Enums;
using NerdStore.Payments.Business.Models;
using NerdStore.Sales.Domain.Models.Order;

namespace NerdStore.Payments.AntiCorruption
{
	public class PagamentoCartaoCreditoFacade : IPaymentCreditCardFacade
	{
		private readonly IPayPalGateway _payPalGateway;
		private readonly IConfigurationManager _configManager;

		public PagamentoCartaoCreditoFacade(IPayPalGateway payPalGateway, IConfigurationManager configManager)
		{
			_payPalGateway = payPalGateway;
			_configManager = configManager;
		}

		public Transaction RealizarPagamento(Order pedido, Payment pagamento)
		{
			var apiKey = _configManager.GetValue("apiKey");
			var encriptionKey = _configManager.GetValue("encriptionKey");

			var serviceKey = _payPalGateway.GetPayPalServiceKey(apiKey, encriptionKey);
			var cardHashKey = _payPalGateway.GetCardHashKey(serviceKey, pagamento.CardNumber);

			var pagamentoResult = _payPalGateway.CommitTransaction(cardHashKey, pedido.Id.ToString(), pagamento.Value);

			// TODO: O gateway de pagamentos que deve retornar o objeto transação
			var transaction = new Transaction
			{
				OrderId = pedido.Id,
				Total = pedido.TotalValue,
				PaymentId = pagamento.Id
			};

			if (pagamentoResult)
			{
				transaction.TransactionStatus = TransactionStatus.Paid;
				return transaction;
			}

			transaction.TransactionStatus = TransactionStatus.Refused;
			return transaction;
		}
	}
}