namespace aspnet_logging_05_cli
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.PlatformAbstractions;

    public class Startup
    {
        private readonly string _basePath;
        
        public Startup(IApplicationEnvironment env)
        {
            _basePath = env.ApplicationBasePath;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<MyClass>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            
            loggerFactory.AddMyLogger(_basePath);

            app.Run(async context =>
            {
                var myClass = context.RequestServices.GetService<MyClass>();

                myClass.DoSomething(1);
                myClass.DoSomething(20);
                myClass.DoSomething(-20);

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}