using FordApi.Web;
using FordApi.Web.Extension;
using FordApi.Web.Middleware;
using Microsoft.OpenApi.Models;

namespace FordApi;

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
        // inject
        services.AddDbContextDI(Configuration);
        services.AddServices();


        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "FordApi", Version = "v1" });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FordApi v1"));
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<HeartbeatMiddleware>();
        app.UseMiddleware<ErrorHandlerMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.AddApplicationServices();
    }
}
