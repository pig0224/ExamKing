using Fur.UnifyResult;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using RESTfulResultProvider = ExamKing.Core.Provider.RESTfulResultProvider;

namespace ExamKing.WebApp.Admin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCorsAccessor();
            services
                .AddControllersWithViews()
                .AddUnifyResult<RESTfulResult, RESTfulResultProvider>();;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCorsAccessor();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}