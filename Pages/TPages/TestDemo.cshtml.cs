using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using PTD = mlpoca.Models.PvtTestData;

namespace mlpoca.Pages.TPages
{
	public class TestDemoModel : Models.MpcPageModel
	{
		public string ResponseText { get; set; }

		public void OnGet()
		{
			// ResponseText = getWorkspacesJSON();
			ResponseText = getPostsJSON();
		}

		private string getWorkspacesJSON(){
			// prepare request body
			string lsURL = string.Format(PTD.ML_Uri, "workspaces?include=participants,creator");
			return getJsonResponse(lsURL);
		}

		private string getPostsJSON()
		{
			// prepare request body
			string lsURL = string.Format(PTD.ML_Uri, "posts"); // ?include=replies,story,user,workspace
			return getJsonResponse(lsURL);
		}

		private string getJsonResponse (string psURL, string psReqJson = ""){

			// Prepare caller
			WebRequest loWrMl = WebRequest.CreateHttp(psURL);
			loWrMl.Credentials = null;
			loWrMl.Method = "GET";
			loWrMl.Headers.Add("Authorization", string.Format("Bearer {0}", PTD.ML_Auth_Token));

			// make call
			HttpWebResponse loResp1 = (HttpWebResponse)loWrMl.GetResponse();
			Console.WriteLine("Call Status: {0} - {1}", loResp1.StatusCode, loResp1.StatusDescription);

			// read response
			Stream loRaw = loResp1.GetResponseStream();
			StreamReader loRespStream = new StreamReader(loRaw);
			string lsRawResponse = loRespStream.ReadToEnd();

			// TODO:
			// Dump all headers
			// 

			//Format response
			string lsJSON = "";
			/*
			JsonTextReader loJO = new JsonTextReader(new StringReader(lsRawResponse));
			lsJSON = JsonConvert.SerializeObject(loJO, Formatting.Indented);
			*/

			JObject loJo = JObject.Parse(lsRawResponse);
			lsJSON = JsonConvert.SerializeObject(loJo, Formatting.Indented);


			return lsJSON;
		}
	}
}
