using MediatR;
using System;
using System.Text.Json.Serialization;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.UpdateCar
{
	public class UpdateCarCommand : IRequest<CarDto>
	{
		[JsonIgnore]
		public Guid Id { get; set; }

		public string Make { get; set; }

		public string Model { get; set; }
	}
}
