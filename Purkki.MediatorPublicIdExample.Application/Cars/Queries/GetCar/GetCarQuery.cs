using MediatR;
using System;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCar
{
	public class GetCarQuery : IRequest<CarDto>
	{
		public Guid Id { get; set; }
	}
}
