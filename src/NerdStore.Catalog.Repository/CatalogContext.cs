using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain.Models;
using NerdStore.Core.Contracts.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.Catalog.Data
{
	public class CatalogContext : DbContext, IUnitOfWork
	{
		public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }

		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			/*foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
				property.Relational().ColumnType == "varchar(100)";*/

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogContext).Assembly);
		}

		public async Task<bool> Commit()
		{
			return await base.SaveChangesAsync() > 0;
		}

		public async Task<bool> RollBack()
		{
			return true;
		}
	}
}
