using System;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Exceptions
{
	public class CarNotFoundException : Exception
	{
		public CarNotFoundException(Guid id) : base($"Car not found with ID {id}")
		{
		}
	}
}
