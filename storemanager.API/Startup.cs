
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using storemanager.Application.Services;
using storemanager.Application.Services.Interfaces;
using storemanager.Infrastructure;
using storemanager.Infrastructure.SeedWorks;
using System.Net.Http;

namespace storemanager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
           
            services.AddControllers();
            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "storemanager.API", Version = "v1" });
            });
            services.AddDbContext<Shop2023Context>(options =>
            {
                //options.UseLazyLoadingProxies(false);
                options.UseSqlServer(Configuration.GetConnectionString("Shop2023Context"));
            }
           );

            services
               .AddScoped<IUnitOfWork, UnitOfWork>()
               .AddScoped(typeof(IRepository<>), typeof(Repository<>))
               .AddScoped<IcustomersService, customersService>()
               .AddScoped<IproductsService, productsService>()
               .AddScoped<IshopsService, shopsService>();

            services.AddScoped(sp => new HttpClient());
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "storemanager.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
