using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NerdStore.Core.DomainObjects
{
	public class BaseController : Microsoft.AspNetCore.Mvc.Controller
	{
		protected Guid clientId = new Guid();

		protected new IActionResult Response<T>(T result)
		{
			return Ok(new { Data = result });
		}

		protected IActionResult Error(Exception ex)
		{
			var error = new
			{
				ErrorMessages = new List<Error>()
				{
					new Error(ex.HResult.ToString(), ex.Message)
				}
			};

			return StatusCode((int)HttpStatusCode.InternalServerError, error);
		}
	}
}
