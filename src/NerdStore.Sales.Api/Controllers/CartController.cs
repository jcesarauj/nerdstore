using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Contract;
using NerdStore.Catalog.Application.ViewModel;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Sales.Domain.Commands;
using NerdStore.Sales.Domain.Contracts.Queries;
using System;
using System.Threading.Tasks;

namespace NerdStore.Sales.Api.Controllers
{
	[Route("api/cart")]
	[ApiController]
	public class CartController : BaseController
	{
		private readonly IProductAppService _productService;
		private readonly IMediatorHandler _mediatorHandler;
		private readonly IOrderQueries _orderQueries;
		public CartController(IProductAppService productService, IMediatorHandler mediatorHandler,
			INotificationHandler<DomainNotification> notifications, IOrderQueries orderQueries) : base(notifications, mediatorHandler)
		{
			_productService = productService;
			_mediatorHandler = mediatorHandler;
			_orderQueries = orderQueries;
		}

		[HttpPost]
		[Route("item/add")]
		public async Task<IActionResult> AddItem([FromBody] AddCartItemCommand addCartItemCommand)
		{
			try
			{
				ProductViewModel product = await _productService.GetById(addCartItemCommand.ProductId);

				if (product == null) return Error("Produto não encontrado", "P0001", System.Net.HttpStatusCode.NotFound);

				AddOrderItemCommand addOrderItemCommand = new(product.ProductId, clientId, product.Name, product.Price, addCartItemCommand.Quantity);
				await _mediatorHandler.SendCommand(addOrderItemCommand);

				return Response(addOrderItemCommand);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromBody] AddCartItemCommand addCartItemCommand)
		{
			try
			{
				var cart = _orderQueries.GetCartClient(this.clientId);
				return Response(cart);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}
	}
}
