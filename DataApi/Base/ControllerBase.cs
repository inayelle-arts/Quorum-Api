using System;
using Microsoft.AspNetCore.Mvc;

namespace Quorum.DataApi.Base
{
	public class ControllerBase : Controller
	{
		protected string GetClaim(string key)
		{
			return User.FindFirst(key).Value;
		}

		protected int UserId => Int32.Parse(GetClaim("id"));
	}
}