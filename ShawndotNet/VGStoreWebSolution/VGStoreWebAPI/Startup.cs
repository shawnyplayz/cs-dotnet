using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VGStoreWebAPI.Models;
using VGStoreWebAPI.Models.Abstract;
using VGStoreWebAPI.Models.Concrete;

namespace VGStoreWebAPI
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
      services.AddMvc();

      services.AddDbContext<VGStoreDbContext>(cfg =>
      {
        cfg.UseSqlServer(Configuration["ConnectionStrings:VGStoreConnection"],
          sqlServerOptionsAction: sqlOptions =>
          {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(20), errorNumbersToAdd: null);
          });
      });
      services.AddScoped<IProductRepository, EFProductRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
      }
      using (var scope = app.ApplicationServices.CreateScope())
      {
        VGStoreDbContext context = scope.ServiceProvider.GetRequiredService<VGStoreDbContext>();
        var createDatabase = context.Database.EnsureCreated();
        if (createDatabase)
        {
          VGStoreSeedData.PopulateVGStore(context);
        }
      }
          app.UseRouting();
      
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
        endpoints.MapGet("/", async context =>
              {
                await context.Response.WriteAsync("Hello World!");
              });
      });
    }
  }
}
