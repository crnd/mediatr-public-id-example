using MediatR;
using System.Collections.Generic;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCars
{
	public class GetCarsQuery : IRequest<List<CarDto>>
	{
	}
}
