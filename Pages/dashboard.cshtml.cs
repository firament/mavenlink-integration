using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mlpoca.Pages
{
	public class dashboardModel : Models.MpcPageModel
	{
		public void OnGet()
		{
			Console.WriteLine("Function {0} called at {1}", "dashboardModel.OnGet()", DateTime.Now.ToString());
			Console.WriteLine(Request.QueryString.ToString());
		}

		[IgnoreAntiforgeryToken(Order = 1001)]
		public void OnPost()
		{
			Console.WriteLine("Function {0} called at {1}", "dashboardModel.OnPost()", DateTime.Now.ToString());
			Console.WriteLine(Request.Form.Count);
		}

	}
}
