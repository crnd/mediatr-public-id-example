using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Purkki.MediatorPublicIdExample.Persistence.Entities;

namespace Purkki.MediatorPublicIdExample.Persistence.Configurations
{
	public class CarConfigurations : PublicEntityConfiguration<Car>
	{
		public override void Configure(EntityTypeBuilder<Car> builder)
		{
			base.Configure(builder);

			builder
				.Property(e => e.Make)
				.IsRequired();

			builder
				.Property(e => e.Model)
				.IsRequired();
		}
	}
}
