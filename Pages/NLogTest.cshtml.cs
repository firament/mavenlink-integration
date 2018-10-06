using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using mlpoca.Models;

using Microsoft.Extensions.Logging;


namespace mlpoca.Pages
{
	public class NLogTestModel : Models.MpcPageModel
	{
		// private readonly ILogger<NLogTestModel> _log;
		public NLogTestModel(ILogger<NLogTestModel> logger) :base(logger)
		{
			// _log = logger;
			_log.LogInformation("Initializing NLogTest");
		}


		public void OnGet()
		{
			_log.LogInformation("Displaying the test NLog page.");
			_log.LogError(
				new Exception("General exception instance to test logs")
				, "This should have an exception"
			);
		}
	}
}
