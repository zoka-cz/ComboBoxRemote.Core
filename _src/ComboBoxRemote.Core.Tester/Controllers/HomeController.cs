using ComboBoxRemote.Core.Tester.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ComboBoxRemote.Core.Tester.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View(new ViewModels.ComboBoxTesterModel());
		}

		[HttpPost]
		public IActionResult Index(ViewModels.ComboBoxTesterModel model)
		{
			if (ModelState.IsValid)
			{
				ViewBag.Message = string.Join(", ", model.StringsSelector.Prepend(model.IntSelector.ToString()));
			}
			else
			{
				ViewBag.Message = "Error";
			}

			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
