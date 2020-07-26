using MediatR;
using System;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommand : IRequest
	{
		public Guid Id { get; set; }
	}
}
