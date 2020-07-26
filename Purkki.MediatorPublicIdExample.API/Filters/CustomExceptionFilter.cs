using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Purkki.MediatorPublicIdExample.Application.Cars.Exceptions;
using System.Net;
using System.Net.Mime;

namespace Purkki.MediatorPublicIdExample.API.Filters
{
	public class CustomExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			HttpStatusCode code;
			switch (context.Exception)
			{
				case CarNotFoundException ex:
					code = HttpStatusCode.NotFound;
					context.HttpContext.Response.ContentType = MediaTypeNames.Application.Json;
					context.Result = new JsonResult(ex.Message);
					break;
				default:
					code = HttpStatusCode.InternalServerError;
					break;
			}

			context.HttpContext.Response.StatusCode = (int)code;
		}
	}
}
