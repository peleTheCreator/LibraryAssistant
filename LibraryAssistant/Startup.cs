using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LibraryAssistant.Options;
using LibraryAssistant.Installers;
using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using LibraryAssistant.API.Filters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using LibraryAssistant.API.MiddleWare;

namespace LibraryAssistant
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallServicesInAssembly(Configuration);
            services.AddAutoMapper(typeof(Startup));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
                option.RoutePrefix = string.Empty;
            });
            app.UseExceptionHandler(builder =>
            {
                builder.Run(
                    async context =>
                    {
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        var exception = error.Error;

                       // var logger = context.RequestServices.GetService<ILogService>();
                        //logger.Error(exception, exception.Message);

                        var result = GlobalExceptionFilter.GetStatusCode<object>(exception);
                        context.Response.StatusCode = (int)result.Item2;
                        context.Response.ContentType = "application/json";

                        var responseJson = JsonConvert.SerializeObject(result.Item1, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                        await context.Response.WriteAsync(responseJson);
                    });
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMiddleware<RequestResponseLoggingMiddleware>();
            app.UseMvcWithDefaultRoute();
        }
    }
}
