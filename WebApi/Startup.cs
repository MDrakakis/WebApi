using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebApi.Data;
using WebApi.Services;

namespace WebApi
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
      // UserDatabaseSettings Dependency Injection
      services.Configure<UserDatabaseSettings>(
        Configuration.GetSection(nameof(UserDatabaseSettings)));

      // Interface is registered in Dependency Injection with a singleton.
      services.AddSingleton<IUserDatabaseSettings>
        (s => s.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);

      services.AddSingleton<UserService>();

      // CORS Globally
      services.AddCors
        (s => s.AddPolicy("CorsPolicy", builder =>
        {
          builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();
        }));

      services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      // CORS Globally
      app.UseCors("CorsPolicy");

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
