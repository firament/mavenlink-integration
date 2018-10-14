using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;
using mlpoca.Models;

namespace mlpoca.Controllers
{
	public class MpaBaseController : Controller
	{


		public readonly ILogger<MpaBaseController> _log;

		/* */
		public MpaBaseController() : base()
		{
			// Console.WriteLine("CTOR 'default' called.");
		}

		public MpaBaseController(ILogger<MpaBaseController> logger) : base()
		{
			_log = logger;
			// Console.WriteLine("CTOR with 'ILogger<MpaBaseController>' called.");
			// _log.LogInformation("CTOR with 'ILogger<MpaBaseController>' called.");
		}

		public override void OnActionExecuting(ActionExecutingContext context){
			base.OnActionExecuting(context);
			_log.LogDebug("Entered Event Method: {0}", @"OnActionExecuting");
			TestCookie(context);
		}

		/*
		 * TODO: Use Interface in place of 'ActionExecutingContext'
		 *		to be usable from both controller and pagemodel
		 * */
		public void TestCookie(ActionExecutingContext context)
		{
			string lsSessionCookieTag;
			var lbCookiExists = context.HttpContext.Request.Cookies.TryGetValue(MpaConstants.CookieName, out lsSessionCookieTag);
			_log.LogDebug("Cookie esists? {0}, Key {1} has value {2}", lbCookiExists, MpaConstants.CookieName, lsSessionCookieTag);

			if (!HttpContext.Request.Cookies.ContainsKey(MpaConstants.CookieName))
			{
				lsSessionCookieTag = Guid.NewGuid().ToString("D");
				_log.LogInformation("Create session tag '{0}' with key {1}", lsSessionCookieTag, MpaConstants.CookieName);
				context.HttpContext.Response.Cookies.Append(MpaConstants.CookieName, lsSessionCookieTag);
			}
		}

	}
}
