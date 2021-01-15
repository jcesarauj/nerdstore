using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdStore.WebApp.UI.Controllers.Admin
{
	public class AdminProductsController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
