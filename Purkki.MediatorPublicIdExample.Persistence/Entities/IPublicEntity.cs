using System;

namespace Purkki.MediatorPublicIdExample.Persistence.Entities
{
	public interface IPublicEntity
	{
		public Guid PublicId { get; set; }
	}
}
