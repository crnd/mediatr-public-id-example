using System;

namespace Purkki.MediatorPublicIdExample.Persistence.Entities
{
	public class Car : IPublicEntity
	{
		public int Id { get; set; }

		public Guid PublicId { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }
	}
}
