using System;
using System.Collections;
using System.Collections.Concurrent;
// using Microsoft.AspNetCore.Hosting;

namespace mlpoca.Models
{
	public class AppConfigData
	{
		public AppConfigData()
		{
			UpdateInstant = DateTime.Now;
		}
		
		public int Version { get; set; } = 0;
		public string Environment { get; set; } = Microsoft.AspNetCore.Hosting.EnvironmentName.Development;
		public Hashtable UserTokensH { get; set; } = new Hashtable();
		// public ConcurrentDictionary<string, string> UserTokensCD { get; set; }

		public string MLKEY { get; set; } = "TBD";
		public string DefaultCode { get; set; } = "demo";
		public string CookieName { get; set; } = "MavenLinkPoC";

		public DateTime UpdateInstant { get; set; }

	}
}
