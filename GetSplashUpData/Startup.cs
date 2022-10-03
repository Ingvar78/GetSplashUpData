using GetSplashUpData.Configurations;
using GetSplashUpData.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace GetSplashUpData
{
    public class Startup
    {

        private readonly ILogger<Startup> _logger;

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddConsole();
                builder.AddEventSourceLogger();
            });
            _logger = loggerFactory.CreateLogger<Startup>();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("ConfigureServices called");
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            services.AddLogging((conf) => conf.SetMinimumLevel(LogLevel.Trace));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo SplashUp API",
                    Description = "A simple example for working with goszakupki.gov ru",
                    TermsOfService = new Uri("https://eger.pro/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Igor Vishenkov",
                        Email = string.Empty,
                        Url = new Uri("https://t.me/vishenkov"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://eger.pro/license"),
                    }
                });
            });

            services.AddMvc();

            var connStr = Configuration.GetConnectionString("ConnectionGDB");
            var connStrD = Configuration.GetConnectionString("DefaultConnection");
            
            InjectorBootStrapper.RegisterServices(services);

        }

        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IServiceProvider services)
        //{
        //    _logger.LogInformation("Configure called");
        //    //For EF6
        //    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        //    if (loggerFactory != null)
        //    {
        //        var logger = services.GetService<ILogger<Startup>>();
        //        logger.LogInformation(env.EnvironmentName);
        //    }


        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    app.UseRouting();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapGet("/", async context =>
        //        {
        //            await context.Response.WriteAsync("Hello World!");
        //        });
        //    });


        //}
    }
}
