using Microsoft.AspNetCore.Mvc;
using Purkki.MediatorPublicIdExample.Application.Cars;
using Purkki.MediatorPublicIdExample.Application.Cars.Commands.CreateCar;
using Purkki.MediatorPublicIdExample.Application.Cars.Commands.DeleteCar;
using Purkki.MediatorPublicIdExample.Application.Cars.Commands.UpdateCar;
using Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCar;
using Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCars;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.API.Controllers
{
	public class CarsController : MediatrControllerBase
	{
		[HttpGet]
		public async Task<ActionResult<List<CarDto>>> GetCars()
		{
			return await Mediator.Send(new GetCarsQuery());
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<CarDto>> GetCar(Guid id)
		{
			return await Mediator.Send(new GetCarQuery { Id = id });
		}

		[HttpPost]
		public async Task<ActionResult<CarDto>> CreateCar(CreateCarCommand command)
		{
			var car = await Mediator.Send(command);
			return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult<CarDto>> UpdateCar(Guid id, UpdateCarCommand command)
		{
			command.Id = id;
			return await Mediator.Send(command);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCar(Guid id)
		{
			await Mediator.Send(new DeleteCarCommand { Id = id });
			return NoContent();
		}
	}
}
