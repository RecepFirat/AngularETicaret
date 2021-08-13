
using AngularETicaret.API.Extensions;
using AngularETicaret.API.Helpers;
using AngularETicaret.API.Middleware;
using AngularETicaret.Core.Interfaces;
using AngularETicaret.Infrastructure.DataContext;
using AngularETicaret.Infrastructure.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AngularETicaret.API
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
            services.AddApplicationServices();
            services.AddAutoMapper(typeof(MappingProfile));//buradaki mappingi ekliyorum
            services.AddControllers();
            services.AddDbContext<StoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<StoreContext>(opt =>
            //{
            //    opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), conf =>
            //    {
            //        conf.MigrationsAssembly("AngularE
            //        Ticaret.API");
            //    });
            //});
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");//her türlü istegi kabul et  diyorum
                });
            });
            services.AddSwaggerDocumentation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseSwaggerDocumention();
            app.UseStatusCodePagesWithReExecute("/error/{0}");//error controllerim calýssýn diye
            app.UseCors("CorsPolicy");
            app.UseRouting();
          
            app.UseAuthorization();
        
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
