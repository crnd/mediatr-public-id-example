using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorPublicIdExample.Application.Cars.Exceptions;
using Purkki.MediatorPublicIdExample.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.UpdateCar
{
	public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarDto>
	{
		private readonly ExampleContext context;
		private readonly IMapper mapper;

		public UpdateCarCommandHandler(ExampleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<CarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
		{
			var car = await context.Cars.FirstOrDefaultAsync(c => c.PublicId == request.Id, cancellationToken);
			if (car == null)
			{
				throw new CarNotFoundException(request.Id);
			}

			mapper.Map(request, car);
			context.Cars.Update(car);
			await context.SaveChangesAsync(cancellationToken);

			return mapper.Map<CarDto>(car);
		}
	}
}
