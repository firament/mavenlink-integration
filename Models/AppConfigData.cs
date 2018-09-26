using System;
using System.Collections;
using System.Collections.Concurrent;

namespace mlpoca.Models
{
	public class AppConfigData
	{
		public AppConfigData()
		{
		}
		
		public int Version { get; set; } = 0;
		public string Environment { get; set; } = "Development";
		public Hashtable UserTokensH { get; set; } = new Hashtable();
		// public ConcurrentDictionary<string, string> UserTokensCD { get; set; }

		public string MLKEY { get; set; } = "TBD";
		public string DefaultCode { get; set; } = "demo";
		public string CookieName { get; set; } = "MavenLinkPoC";

	}
}
