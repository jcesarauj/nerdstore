using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NerdStore.Catalog.Application.Contract;
using NerdStore.Catalog.Application.Services;
using NerdStore.Catalog.Data;
using NerdStore.Catalog.Data.Repository;
using NerdStore.Catalog.Domain.Contracts.Repository;
using NerdStore.Core.Comunication.Handler;
using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Sales.Data.Repository;
using NerdStore.Sales.Domain.Commands;
using NerdStore.Sales.Domain.Commands.Order;
using NerdStore.Sales.Domain.Contracts.Queries;
using NerdStore.Sales.Domain.Contracts.Repository;
using NerdStore.Sales.Domain.Events;
using NerdStore.Sales.Domain.Events.Order;
using NerdStore.Sales.Domain.Handlers;
using NerdStore.Sales.Domain.Queries;
using NerdStore.Sales.Domain.Validation.Command.Order;

namespace NerdStore.Sales.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<CatalogContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddControllers();

			services.AddMediatR(typeof(Startup));
			// Mediator
			services.AddScoped<IMediatorHandler, MediatorHandler>();

			services.AddScoped<IRequestHandler<AddOrderItemCommand, bool>, OrderCommandHandler>();
			services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

			//Service
			services.AddScoped<IProductAppService, ProductAppService>();

			//Repository
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IProductRepository, ProductRepository>();

			//Event
			services.AddScoped<INotificationHandler<DraftOrderStartedEvent>, OrderEventHandler>();
			services.AddScoped<INotificationHandler<OrderItemAddedEvent>, OrderEventHandler>();
			services.AddScoped<INotificationHandler<OrderItemUpdatedEvent>, OrderEventHandler>();

			//Valida o comando no momento do disparo
			services.AddTransient<IValidator<StartOrderCommand>, StartOrderValidation>();

			//Queries
			services.AddScoped<IOrderQueries, OrderQueries>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
