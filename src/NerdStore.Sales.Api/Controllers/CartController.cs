using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Contract;
using NerdStore.Catalog.Application.ViewModel;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Sales.Domain.Commands;
using NerdStore.Sales.Domain.Commands.Cart;
using NerdStore.Sales.Domain.Commands.Order;
using NerdStore.Sales.Domain.Contracts.Queries;
using System;
using System.Threading.Tasks;

namespace NerdStore.Sales.Api.Controllers
{
	[Route("api/carrinho")]
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
		[Route("item/adicionar")]
		public async Task<IActionResult> AddItem([FromBody] AddCartItemCommand addCartItemCommand)
		{
			try
			{
				//teste
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

		[HttpPost]
		[Route("item/remover")]
		public async Task<IActionResult> RemoveItem([FromBody] RemoveCartItemCommand removeCartItemCommand)
		{
			try
			{
				var produto = await _productService.GetById(removeCartItemCommand.ProductId);
				if (produto == null) return BadRequest();

				var command = new RemoveItemOrderCommand(this.clientId, removeCartItemCommand.OrderItemId);
				await _mediatorHandler.SendCommand(command);

				return Response(command);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}

		[HttpPost]
		[Route("item/atualizar")]
		public async Task<IActionResult> Update([FromBody] UpdateCartItemCommand updateCartItemCommand)
		{
			try
			{
				var produto = await _productService.GetById(updateCartItemCommand.ProductId);
				if (produto == null) return BadRequest();

				var command = new UpdateItemOrderCommand(this.clientId, updateCartItemCommand.ProductId, updateCartItemCommand.Quantity);
				await _mediatorHandler.SendCommand(command);

				return Response(command);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}

		[HttpPost]
		[Route("aplicarvoucher")]
		public async Task<IActionResult> ApplyVoucher([FromBody] VoucherCommand updateCartItemCommand)
		{
			try
			{
				var command = new ApplyVoucherOrderCommand(this.clientId, updateCartItemCommand.VoucherCode);
				await _mediatorHandler.SendCommand(command);
				return Response(command);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}

		[HttpPost]
		[Route("iniciarpedido")]
		public async Task<IActionResult> StartOrder([FromBody] CartCommand cartCommand)
		{
			try
			{
				var carrinho = await _orderQueries.GetCartClient(this.clientId);

				var command = new StartOrderCommand(cartCommand.OrderId, this.clientId, cartCommand.TotalValue, cartCommand.Payment.CardName,
					cartCommand.Payment.CardNumber, cartCommand.Payment.Expiration, cartCommand.Payment.Cvv);

				await _mediatorHandler.SendCommand(command);
				return Response(command);
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

		[HttpGet]
		[Route("healthcheck")]
		public async Task<IActionResult> Get()
		{
			try
			{
				return Response("Olá funcionando");
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}
	}
}
