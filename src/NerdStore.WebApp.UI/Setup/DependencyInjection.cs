using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalog.Aplication.Contract;
using NerdStore.Catalog.Aplication.Services;
using NerdStore.Catalog.Data;
using NerdStore.Catalog.Data.Repository;
using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Catalog.Domain.Contracts.Service;
using NerdStore.Catalog.Domain.Service;
using NerdStore.Core.Contracts.Mediatr;
using NerdStore.Core.Mediatr;

namespace NerdStore.WebApp.UI.Setup
{
	public static class DependencyInjection
	{
		public static void RegisterServices(this IServiceCollection services)
		{
			services.AddScoped<IMediaTrHandler, MediaTrHandler>();

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IProductAppService, ProductAppService>();
			services.AddScoped<IStockService, StockService>();
			services.AddScoped<CatalogContext>();
		}
	}
}
