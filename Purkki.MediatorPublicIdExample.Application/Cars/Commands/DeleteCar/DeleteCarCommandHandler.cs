using MediatR;
using Microsoft.EntityFrameworkCore;
using Purkki.MediatorPublicIdExample.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Purkki.MediatorPublicIdExample.Application.Cars.Commands.DeleteCar
{
	public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
	{
		private readonly ExampleContext context;

		public DeleteCarCommandHandler(ExampleContext context)
		{
			this.context = context;
		}

		public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
		{
			var car = await context.Cars.FirstOrDefaultAsync(c => c.PublicId == request.Id, cancellationToken);
			if (car != null)
			{
				context.Cars.Remove(car);
				await context.SaveChangesAsync(cancellationToken);
			}

			return Unit.Value;
		}
	}
}
