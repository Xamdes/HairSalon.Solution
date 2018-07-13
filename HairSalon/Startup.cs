using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HairSalon
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
      .SetBasePath(env.ContentRootPath)
      .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration
    {
      get;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
        name: "default",
        template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Hello World!");
      });
    }
  }

  public static class DBConfiguration
  {
    private static string _connection = "server=localhost;user id=root;password=root;port=8889;database=steven_colburn;Convert Zero Datetime=True;Allow User Variables=true;";
    private static string _connectionTest = "server=localhost;user id=root;password=root;port=8889;database=steven_colburn_test;Convert Zero Datetime=True;Allow User Variables=true;";

    public static string GetConnection()
    {
      return _connection;
    }

    public static string GetTestConnection()
    {
      return _connectionTest;
    }

    public static void SetConnection(string s)
    {
      _connection = s;
    }

    public static void DefaultConnection()
    {
      _connection = "server=localhost;user id=root;password=root;port=8889;database=steven_colburn;Convert Zero Datetime=True;Allow User Variables=true;";
    }
  }
}
