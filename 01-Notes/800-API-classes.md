# Tools to Consume API

## Preferred 
**[HttpWebRequest Class](https://docs.microsoft.com/en-us/dotnet/api/system.net.httpwebrequest?view=netcore-2.1)**

***

## Source 1
- https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client

## Source 2
> https://dzone.com/articles/a-few-great-ways-to-consume-restful-apis-in-c
- HttpWebRequest/Response class
	- https://docs.microsoft.com/en-us/dotnet/api/system.net.webrequest?view=netcore-2.1
	- offers fine-grained control over every aspect of the request making process
	- does not block the user interface
	- to send data to the resource, the GetRequestStream method returns a Stream object to use to send data. 
	- The BeginGetRequestStream and EndGetRequestStream methods provide asynchronous access to the send data stream.
	- HttpWebRequest.Headers Property
		- Specifies a collection of the name/value pairs that make up the HTTP headers.
	- HttpWebRequest.ContentType Property
		- Gets or sets the value of the Content-type HTTP header.
	- HttpWebRequest.UseDefaultCredentials Property

- WebClient class
	- https://docs.microsoft.com/en-us/dotnet/api/system.net.webclient?view=netcore-2.1
	- Provides common methods for sending data to and receiving data from a resource identified by a URI.
	- wrapper around HttpWebRequest
	```cs
	var client = new WebClient();
	client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
	var response = client.DownloadString("https://api.github.com/repos/restsharp/restsharp/releases");
	var releases = JArray.Parse(response);
	```
	- Namespace: System.Net
	- Assemblies: System.dll, netstandard.dll, System.Net.WebClient.dll


- HttpClient class
	- can send multiple requests with the single instance of HttpClient
	- Strongly typed headers
	- Shared Caches, cook­ies, and credentials
- RestSharp NuGet package
	- available as a NuGet package
	- nbuilt Authentication and Serialization/Deserialization mechanisms
	- upports OAuth1, OAuth2, Basic, NTLM, and Parameter-based Authentication
	- https://github.com/restsharp/RestSharp/wiki/Getting-Started
	- Not yet availaible for .Net Core
- ServiceStack Http Utils
	- https://servicestack.net/
	- HTTP Utils
		- http://docs.servicestack.net/http-utils
