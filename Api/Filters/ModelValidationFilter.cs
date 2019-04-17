using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Quorum.Api.Filters
{
	public sealed class ModelValidationFilter : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			if (context.ModelState.IsValid)
			{
				await next();
			}

			var errors = context.ModelState.Select(pair => new { pair.Key, pair.Value.Errors });

			context.Result = new BadRequestObjectResult(errors);
		}
	}
}