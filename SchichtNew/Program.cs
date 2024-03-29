using SchichtNew.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SchichtNew
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            /*  var host = CreateHostBuilder(args).Build();
              using (var scope=host.Services.CreateScope())
              {
                  Databaseinitializator.Init(scope.ServiceProvider);
              }
              host.Run();*/
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }

    /* public static class Databaseinitializator
     { 
         public static void Init(IServiceProvider scopeServiceProvider)
         {
             var userManager = scopeServiceProvider.GetService<UserManager<Executors>>();

             var user = new Executors
             {
                 FIO_executor = "1",
                 Roles="2",
             };
             var result= userManager.CreateAsync(user,"123").GetAwaiter().GetResult();
             if(result.Succeeded)
             {
                 userManager.AddClaimAsync(user,new Claim(ClaimTypes.Role, "Administrator")).GetAwaiter().GetResult();  
             }
         }

     }*/
}




