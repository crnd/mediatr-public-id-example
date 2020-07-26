using AutoMapper;
using MediatR;
using Purkki.MediatorPublicIdExample.Persistence;
using Purkki.MediatorPublicIdExample.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.CreateCar
{
	public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarDto>
	{
		private readonly ExampleContext context;
		private readonly IMapper mapper;

		public CreateCarCommandHandler(ExampleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<CarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
		{
			var car = mapper.Map<Car>(request);
			context.Cars.Add(car);
			await context.SaveChangesAsync(cancellationToken);

			return mapper.Map<CarDto>(car);
		}
	}
}
