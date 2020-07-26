using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorPublicIdExample.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Queries.GetCars
{
	public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, List<CarDto>>
	{
		private readonly ExampleContext context;
		private readonly IMapper mapper;

		public GetCarsQueryHandler(ExampleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<List<CarDto>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
		{
			return await context.Cars
				.Select(c => mapper.Map<CarDto>(c))
				.ToListAsync(cancellationToken);
		}
	}
}
