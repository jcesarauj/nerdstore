using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalog.Application.Contract;
using NerdStore.Catalog.Application.ViewModel;
using NerdStore.Core.Contracts.Mediatr;
using NerdStore.Core.DomainObjects;
using NerdStore.Sales.Api.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Sales.Api.Application.Commands;

namespace NerdStore.Sales.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : BaseController
	{
		private readonly IProductAppService _productService;
		private readonly IMediatorHandler _mediatorHandler;
		public CartController(IProductAppService productService, IMediatorHandler mediatorHandler)
		{
			_productService = productService;
			_mediatorHandler = mediatorHandler;
		}

		[HttpPost]
		[Route("cart/item/add")]
		public async Task<IActionResult> AddItem(Guid id, int quantity)
		{
			try
			{
				ProductViewModel product = await _productService.GetById(id);
				if (product == null) return NotFound();

				AddOrderItemCommand addOrderItemCommand = new(product.ProductId, clientId, product.Name, product.Price, quantity);
				await _mediatorHandler.SendCommand(addOrderItemCommand);

				return Response(addOrderItemCommand);
			}
			catch (Exception ex)
			{
				return Error(ex);
			}
		}
	}
}
