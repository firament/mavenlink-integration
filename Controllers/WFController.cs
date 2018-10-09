using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using mlpoca.Models;

namespace mlpoca.Controllers
{
	[Controller()]
	public class WFController : MpaBaseController
	{

		private IApplicationLifetime ApplicationLifetime { get; set; }


		public WFController(ILogger<WFController> logger, IApplicationLifetime appLifetime) : base(logger)
		{
			_log.LogInformation("Hooking into Application Lifetime");
			ApplicationLifetime = appLifetime;
		}

		[Route("WF")]
		[Route("WF/Index")]
		public IActionResult Index()
		{
			_log.LogDebug("WF Index page being served");
			// return Ok("Warning! This page is for developer usage only. \n Please do NOT come back here.");
			return View(model: new NLogLevels());
		}

		[Route("WF/ForceDown")]
		public IActionResult ShutdownSite()
		{
			// Later bro
			_log.LogWarning("Shutting down the application NOW.");
			ApplicationLifetime.StopApplication();
			return Ok("Application is shutting down Now.");
		}

		[HttpGet]
		[Route("WF/NLogTest/{Level:int:range(1,5)}")]
		public IActionResult NLogTest(int Level)
		{
			// Test snippet only...
			/*
			StringBuilder lsbGuids = new StringBuilder();
			lsbGuids.AppendLine("GUID Sample Formats - BEGIN");
			lsbGuids.AppendLine(string.Format("N --  {0}", Guid.NewGuid().ToString("N")));
			lsbGuids.AppendLine(string.Format("D --  {0}", Guid.NewGuid().ToString("D")));
			lsbGuids.AppendLine(string.Format("B --  {0}", Guid.NewGuid().ToString("B")));
			lsbGuids.AppendLine(string.Format("P --  {0}", Guid.NewGuid().ToString("P")));
			lsbGuids.AppendLine(string.Format("X --  {0}", Guid.NewGuid().ToString("X")));
			lsbGuids.AppendLine("GUID Sample Formats - END");
			_log.LogDebug("GUID Formats: {0}", lsbGuids.ToString());
			*/

			Microsoft.Extensions.Logging.LogLevel llTestLevel = (Microsoft.Extensions.Logging.LogLevel)Level;
			string lsLogEntry = string.Format("Test-Value = {0}, Log-Level = {1}"
												, Guid.NewGuid().ToString("D")
												, llTestLevel.ToString()
												);
			ViewData["Message"] = string.Format("Wrote entry to log '{0}'", lsLogEntry);
			_log.Log(llTestLevel, lsLogEntry);
			return View(viewName: "Index", model: new mlpoca.Models.NLogLevels());

			// Legacy Code
			/* 
			Microsoft.Extensions.Logging.LogLevel llTestLevel = (Microsoft.Extensions.Logging.LogLevel)Level;
			string lsGUID = Guid.NewGuid().ToString("D");
			string lsLogEntry = string.Format("Test-Value = {0}, Log-Level = {1}", lsGUID, llTestLevel.ToString());

			_log.Log(llTestLevel, lsLogEntry);

			ViewData["Message"] = string.Format("Wrote entry to log '{0}'", lsLogEntry);
			// return View("Index");
			return View(viewName: "Index", model: new mlpoca.Models.NLogLevels());
			*/
		}

		[NonAction]
		private void Sample()
		{
			
			_log.LogInformation("Place holder function to test code before writing to razor page.");
		}

	}
}
