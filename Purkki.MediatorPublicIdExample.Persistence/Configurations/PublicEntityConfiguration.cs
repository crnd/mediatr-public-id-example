using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purkki.MediatorPublicIdExample.Persistence.Entities;

namespace Purkki.MediatorPublicIdExample.Persistence.Configurations
{
	public abstract class PublicEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IPublicEntity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder
				.HasIndex(e => e.PublicId)
				.IsUnique();
		}
	}
}
