using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorPublicIdExample.Application.Cars.Exceptions;
using Purkki.MediatorPublicIdExample.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCar
{
	public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarDto>
	{
		private readonly ExampleContext context;
		private readonly IMapper mapper;

		public GetCarQueryHandler(ExampleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<CarDto> Handle(GetCarQuery request, CancellationToken cancellationToken)
		{
			var car = await context.Cars.FirstOrDefaultAsync(c => c.PublicId == request.Id, cancellationToken);
			if (car == null)
			{
				throw new CarNotFoundException(request.Id);
			}

			return mapper.Map<CarDto>(car);
		}
	}
}
