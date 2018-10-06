using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

// using mlpoca.Models;
using Microsoft.Extensions.Logging;


namespace mlpoca.Models
{
	/// <summary>
	/// Base model for use across application
	/// </summary>
	public class MpcPageModel : PageModel
	{
		public readonly ILogger<MpcPageModel> _log;

		/* */
		public MpcPageModel() : base()
		{
			if (AppConfig == null)
			{
				AppConfig = new Models.AppConfigData();
				Console.WriteLine("CTOR 'default' called.");
			}
		}

		public MpcPageModel(ILogger<MpcPageModel> logger) : base()
		{
			_log = logger;
			Console.WriteLine("CTOR with 'ILogger<MpcPageModel>' called.");
			_log.LogInformation("CTOR with 'ILogger<MpcPageModel>' called.");
		}


		public MpcPageModel(AppConfigData pAppConfigData) : base()
		{
			AppConfig = pAppConfigData;
			Console.WriteLine("CTOR with 'AppConfigData' called.");
		}

		public static AppConfigData AppConfig { get; set; }

		public AppConfigData InjAppConfig { get; set; }

		public void TestCookie(Microsoft.AspNetCore.Mvc.Filters.PageHandlerSelectedContext context){
			_log.LogInformation("Testing CALLER tag for this entry.");

			string lsSessionCookieTag;
			var lbCookiExists = context.HttpContext.Request.Cookies.TryGetValue(MpaConstants.CookieName, out lsSessionCookieTag);
			_log.LogInformation("Cookie esists? {0}, has value {1}", lbCookiExists, lsSessionCookieTag);

			if (!HttpContext.Request.Cookies.ContainsKey(MpaConstants.CookieName))
			{
				lsSessionCookieTag = Guid.NewGuid().ToString("D");
				_log.LogInformation("Creating session Cookie tag with value '{0}'", lsSessionCookieTag);
				context.HttpContext.Response.Cookies.Append(MpaConstants.CookieName, lsSessionCookieTag);
			}
		}

		/*
		Testing Event handling
		*/
		// Called before the handler method executes, after model binding is complete.
		public override void OnPageHandlerExecuting(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context)
		{
			// for now only write a mesg to console
			Console.WriteLine("Entered Event Method: {0}", @"OnPageHandlerExecuting");
			_log.LogDebug("Entered Event Method: {0}", @"OnPageHandlerExecuting");
		}

		// Called after a handler method has been selected, but before model binding occurs.
		public override void OnPageHandlerSelected(Microsoft.AspNetCore.Mvc.Filters.PageHandlerSelectedContext context)
		{
			// for now only write a mesg to console
			Console.WriteLine("Entered Event Method: {0}", @"OnPageHandlerSelected");
			_log.LogDebug("Entered Event Method: {0}", @"OnPageHandlerSelected");
			TestCookie(context);
		}

		/*
		// Called asynchronously after the handler method has been selected, but before model binding occurs.
		public override System.Threading.Tasks.Task OnPageHandlerSelectionAsync(Microsoft.AspNetCore.Mvc.Filters.PageHandlerSelectedContext context){
			// for now only write a mesg to console
			Console.WriteLine("Entered Event Method: {0}", @"OnPageHandlerSelectionAsync");
		}

		// Called asynchronously before the handler method is invoked, after model binding is complete.
		public override System.Threading.Tasks.Task OnPageHandlerExecutionAsync(Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutingContext context, Microsoft.AspNetCore.Mvc.Filters.PageHandlerExecutionDelegate next){
			// for now only write a mesg to console
			Console.WriteLine("Entered Event Method: {0}", @"OnPageHandlerExecutionAsync");
		}
		*/

	}
}
