using MediatR;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommand : IRequest<CarDto>
	{
		public string Make { get; set; }

		public string Model { get; set; }
	}
}
