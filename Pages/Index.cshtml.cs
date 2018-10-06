using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;

namespace mlpoca.Pages
{
	public class IndexModel : Models.MpcPageModel
	{
		public IndexModel(ILogger<IndexModel> logger) :base (logger)
		{
			_log.LogInformation("Initializing IndexModel");
		}


		public void OnGet()
		{
			string lsSessionCookieTag;
			var lbCookiExists = HttpContext.Request.Cookies.TryGetValue(Models.MpaConstants.CookieName, out lsSessionCookieTag);
			_log.LogDebug("Cookie Value is {0}");
			_log.LogInformation("Index page says hello");
		}
	}
}
