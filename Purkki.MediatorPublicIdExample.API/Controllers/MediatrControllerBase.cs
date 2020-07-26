using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Purkki.MediatorPublicIdExample.API.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public abstract class MediatrControllerBase : ControllerBase
	{
		private IMediator mediator;

		protected IMediator Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
	}
}
