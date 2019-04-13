using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Quorum.Api.Controllers
{
	[Route("api/test")]
	public sealed class TestController : Controller
	{
		private readonly IConfiguration _configuration;

		public TestController(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		[HttpGet]
		public string Get()
		{
			return "OK";
		}
	}
}