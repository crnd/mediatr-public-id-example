using Microsoft.EntityFrameworkCore;
using Purkki.MediatorPublicIdExample.Persistence.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Persistence
{
	public class ExampleContext : DbContext
	{
		public ExampleContext(DbContextOptions<ExampleContext> options) : base(options)
		{
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var publicEntityEntries = ChangeTracker.Entries<IPublicEntity>()
				.Where(e => e.State == EntityState.Added)
				.ToList();
			foreach (var entry in publicEntityEntries)
			{
				entry.Entity.PublicId = Guid.NewGuid();
			}

			return base.SaveChangesAsync(cancellationToken);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleContext).Assembly);
		}

		public DbSet<Car> Cars { get; set; }
	}
}
