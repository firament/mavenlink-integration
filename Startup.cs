using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using mlpoca.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using PTD = mlpoca.Models.PvtTestData;


namespace mlpoca
{
    public class Startup
    {
        public Models.AppConfigData AppConfig { get; set; }
        public Startup(IConfiguration configuration)
        {
			Console.WriteLine("Function {0} called at {1}", "Startup.Startup(IConfiguration configuration)", DateTime.Now.ToString());
            Configuration = configuration;

			AppConfig = new AppConfigData();
			AppConfig.Version = 25;
			Console.WriteLine("ApCfg.Version = {0}", AppConfig.Version);
            
            // TODO: Fix dependency injection issue.
            // Dirty workaround using static prop
			Models.MpcPageModel.AppConfig = AppConfig;

		}

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			Console.WriteLine("Function {0} called at {1}", "Startup.ConfigureServices(IServiceCollection services)", DateTime.Now.ToString());
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

			services.AddSession(options =>
				{
					options.IdleTimeout = TimeSpan.FromMinutes(3);
					options.Cookie.HttpOnly = false;
				}
			);

			services
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options => {
                })
				;


			services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                // .AddRazorPagesOptions(o=> o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()))
                ;

			// services.AddSingleton<Models.AppConfigData
			services.AddSingleton<Models.AppConfigData, AppConfigData>();
		}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

			Console.WriteLine("Function {0} called at {1}", "Startup.Configure(IApplicationBuilder app, IHostingEnvironment env)", DateTime.Now.ToString());
            if (env.IsDevelopment())
            {
			    Models.MpcPageModel.AppConfig.Environment = EnvironmentName.Development;
                app.UseDeveloperExceptionPage();
            }
            else
            {
				Models.MpcPageModel.AppConfig.Environment = EnvironmentName.Production;
				app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
			app.UseMvc();
        }
    }
}
