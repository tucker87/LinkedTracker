using System.Linq;
using LinkedTracker.Data;
using LinkedTracker.Hubs;
using M6T.Core.TupleModelBinder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Formatter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LinkedTracker.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:8088")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

            services.AddOData();

            services.AddMvc(options => {
                options.ModelBinderProviders.Insert(0, new TupleModelBinderProvider());

                foreach (var formatter in options.OutputFormatters
                                            .OfType<ODataOutputFormatter>()
                                            .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
                foreach (var formatter in options.InputFormatters
                                            .OfType<ODataInputFormatter>()
                                            .Where(it => !it.SupportedMediaTypes.Any()))
                {
                    formatter.SupportedMediaTypes.Add(
                        new MediaTypeHeaderValue("application/prs.mock-odata"));
                }
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo  { Title = "My API", Version = "v1" });
            });

            services.AddSingleton<IRoomRepository, RoomRepository>();
            services.AddSingleton<IPointOfInterestRepository, PointOfInterestRepository>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(MyAllowSpecificOrigins); 

            app.UseHttpsRedirection();
            // app.UseMvc(routeBuilder => {
            //     routeBuilder.EnableDependencyInjection();
            //     routeBuilder.Expand().Select().Count().OrderBy().Filter();
            // });

            app.UseRouting();

            app.UseEndpoints(endPoints => {
                endPoints.MapHub<RoomHub>("/room-hub");
                endPoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
