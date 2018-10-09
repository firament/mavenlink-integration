using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;

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

	}
}
