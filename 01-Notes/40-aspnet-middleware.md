# ASP.NET Core Middleware
> https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.1
- Each component:
    - Chooses whether to pass the request to the next component in the pipeline.
    - Can perform work before and after the next component in the pipeline is invoked.
- Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.
- Request delegates are configured using Run, Map, and Use extension methods. 
- An individual request delegate can be specified in-line as an anonymous method (called in-line middleware), or it can be defined in a reusable class. 
- These reusable classes and in-line anonymous methods are middleware, also called middleware components. 
- Each middleware component in the request pipeline is responsible for invoking the next component in the pipeline or short-circuiting the pipeline.
- 
- Each delegate can perform operations before and after the next delegate. 
- A delegate can also decide to not pass a request to the next delegate, which is called short-circuiting the request pipeline. 
- Short-circuiting is often desirable because it avoids unnecessary work.
- The first Run delegate terminates the pipeline.
- **Warning** Don't call next.Invoke after the response has been sent to the client.
- Order
	- The order that middleware components are added in the Startup.Configure method defines the order in which the middleware components are invoked on requests 
	- and the reverse order for the response. 
	- The order is critical
- Map
	- Map extensions are used as a convention for branching the pipeline. 
	- Map* branches the request pipeline based on matches of the given request path. 
	- Map supports nesting
	- Map can also match multiple segments at once
		```cs
		public class Startup
		{
			private static void HandleMultiSeg(IApplicationBuilder app)
			{
				app.Run(async context =>
				{
					await context.Response.WriteAsync("Map multiple segments.");
				});
			}

			public void Configure(IApplicationBuilder app)
			{
				app.Map("/map1/seg1", HandleMultiSeg);
				app.Run(async context =>
				{
					await context.Response.WriteAsync("Hello from non-Map delegate.");
				});
			}
		}	
		```

## Write middleware
```cs
public class Startup
{
    public void Configure(IApplicationBuilder app)
    {
        app.Use((context, next) =>
        {
            var cultureQuery = context.Request.Query["culture"];
            if (!string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
            }

            // Call the next delegate/middleware in the pipeline
            return next();
        });

        app.Run(async (context) =>
        {
            await context.Response.WriteAsync(
                $"Hello {CultureInfo.CurrentCulture.DisplayName}");
        });

    }
}
```

- see `The following code calls the middleware from Startup.Configure:`
