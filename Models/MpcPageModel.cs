using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

using mlpoca.Models;

namespace mlpoca.Models
{
	/// <summary>
	/// Base model for use across application
	/// </summary>
	public class MpcPageModel :PageModel
	{
		/* */
		public MpcPageModel():base()
		{
			if (AppConfig == null)
			{
				AppConfig = new Models.AppConfigData();
			}
		}

		public MpcPageModel(AppConfigData pAppConfigData) :base()
		{
			AppConfig = pAppConfigData;
		}

		public static AppConfigData AppConfig { get; set; }

		public AppConfigData InjAppConfig { get; set; }
	}
}
