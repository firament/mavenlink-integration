using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace mlpoca.Models
{
	public class NLogLevels
	{
		public NLogLevel[] Levels { get; set; }

		public NLogLevels()
		{
			Levels = new List<NLogLevel>()
			{
				// new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Trace),
				// value of 0 is breaking Razor. investigate.
				new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Debug),
				new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Information),
				new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Warning),
				new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Error),
				new NLogLevel(Microsoft.Extensions.Logging.LogLevel.Critical),
			}
			.ToArray();
		}
	}

	public class NLogLevel
	{
		public int Value { get; set; }
		public string Name { get; set; }
		public NLogLevel(int piValue, string lsName)
		{
			Value = piValue;
			Name = lsName;
		}
		public NLogLevel(Microsoft.Extensions.Logging.LogLevel pLevel)
		{
			Value = (int)pLevel;
			Name = pLevel.ToString();
		}
	}
}
