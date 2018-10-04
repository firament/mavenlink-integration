using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace mlpoca
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// NLog: setup the logger first to catch all errors
			/*
			var logger = NLog.Web.NLogBuilder
							.ConfigureNLog("NLog.config")
							.GetCurrentClassLogger()
							;
			string lsEnv = Environment.CommandLine;
			string lsDir = Environment.CurrentDirectory;
			Console.WriteLine("Env = {0}, Dir = {1}", lsEnv, lsDir);
			*/

			string lsNlogConfog = (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development) 
									? "NLog.Development.config" 
									: "NLog.config"
									;

			NLog.Logger logger = NLog.Web.NLogBuilder
									.ConfigureNLog(lsNlogConfog)
									.GetCurrentClassLogger()
									;

			try
			{
				logger.Debug("init main");
				CreateWebHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				//NLog: catch setup errors
				logger.Error(ex, "Stopped program because of exception");
				throw;
			}
			finally
			{
				// Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
				NLog.LogManager.Shutdown();
			}


		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost
				.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.ConfigureLogging(logging =>
				{
					logging.ClearProviders();
					logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
				})
				.UseNLog()  // NLog: setup NLog for Dependency injection
				;
	}
}
