using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sat.Recruitment.Application;
using Sat.Recruitment.Infrastructure;
using Sat.Recruitment.Shared;
using Sat.Recruitment.Shared.Configuration.Extensions;
using Sat.Recruitment.Shared.Models.Configuration.Implementations;

namespace Sat.Recruitment.Api
{
    public class Startup
    {
        /// <summary>
        /// Injected Configuration (AppSettings + Envs + Common)
        /// </summary>
        public IConfiguration Configuration { get; }

        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationSettings _applicationSettings;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
            _applicationSettings = Configuration.GetAndValidate<ApplicationSettings>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddShared(_webHostEnvironment, _applicationSettings);    

            services.AddInfrastructure(_applicationSettings);

            services.AddApplication();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        /// <param name="apiVersionDescriptionProvider"></param>
        public void Configure(IApplicationBuilder applicationBuilder, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (_webHostEnvironment.IsDevelopment())
                applicationBuilder.UseDeveloperExceptionPage();

            applicationBuilder.UseRouting();

            applicationBuilder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            applicationBuilder.UseShared(_webHostEnvironment, apiVersionDescriptionProvider);
        }
    }
}
