using Microsoft.EntityFrameworkCore;
using NerdStore.Core.Contracts.Data;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages;
using NerdStore.Sales.Data;
using NerdStore.Sales.Domain.Models;
using NerdStore.Sales.Domain.Models.Order;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data
{
	public class SalesContext : DbContext, IUnitOfWork
	{
		private readonly IMediatorHandler _mediatorHandler;
		public SalesContext(DbContextOptions<SalesContext> options, IMediatorHandler mediatorHandler) : base(options)
		{
			_mediatorHandler = mediatorHandler;
		}

		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Voucher> Vouchers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.Relational().ColumnType == "varchar(100)";*/

			modelBuilder.Ignore<Event>();

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(SalesContext).Assembly);
		}

		public async Task<bool> Commit()
		{
			var success = await base.SaveChangesAsync() > 0;
			if (success) await _mediatorHandler.PublishEvents(this);

			return success;
		}

		public async Task<bool> RollBack()
		{
			return true;
		}
	}
}
