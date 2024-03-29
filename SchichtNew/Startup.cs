using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using SchichtNew.Models;
using SchichtNew.Data;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace SchichtNew
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            string? connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<SchichtDbContext>(options =>
                options.UseSqlServer(connection));

           services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<SchichtDbContext>();

            services.AddControllersWithViews();

            services.AddControllersWithViews().AddJsonOptions(x =>
              x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm@.";
            });


            /*services.AddScoped<IChemicalElement,ChemicalElementRepository>();
            services.AddScoped<IMaterial, MaterialRepository>();
            services.AddScoped<IDelivery, DeliveryRepository>();
            services.AddScoped<IMetalStage, MetalStageRepository>();*/
           // services.AddScoped<IMetalStage>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
