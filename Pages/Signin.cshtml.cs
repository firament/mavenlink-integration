using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.Extensions.Logging;

namespace mlpoca.Pages
{
	public class SigninModel : Models.MpcPageModel
	{
		public SigninModel(ILogger<SigninModel> logger) : base(logger)
		{
			// _log = logger;
			_log.LogInformation("Initializing NLogTest");
		}

		public void OnGet()
		{
			Console.WriteLine("Function {0} called at {1}", "SigninModel.OnGet()", DateTime.Now.ToString());
			Console.WriteLine("Called with Query String {0}", Request.QueryString);

			Console.WriteLine("AppConfig.CookieName = {0}", AppConfig.CookieName);
			

			// HttpContext.Session.Id
			string lsCode = Request.Query["code"];

			
			


			// token is demo

			// token is user

			// token is signout
		}

		private bool DoSignIn()
		{
			var loUserClaims = new List<Claim>
			{
				new Claim(ClaimTypes.Role, "Demo"),
				new Claim(ClaimTypes.SerialNumber, ""),
			};

			var loUserID = new ClaimsIdentity(
				  loUserClaims
				, CookieAuthenticationDefaults.AuthenticationScheme
			);

			var loAuthProps = new AuthenticationProperties
			{
				IsPersistent = false,
				AllowRefresh = true,
			};

			HttpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme
				, new ClaimsPrincipal(loUserID)
				, loAuthProps
				);

			return true;
		}

		private bool DoSignOut()
		{
			HttpContext.SignOutAsync(
				CookieAuthenticationDefaults.AuthenticationScheme
				);
			return false;
		}

	}
}
