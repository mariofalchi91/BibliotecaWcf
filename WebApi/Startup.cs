using BiblioCore;
using EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace WebApi
{
    public class Startup
    {
        //sfruttiamo la reflection
        public string ApplicationName = Assembly.GetEntryAssembly().GetName().Name;
        public string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers();

            //configurazione dipendency injection
            services.AddTransient<IMainBL, MainBL>();
            services.AddTransient<ILibroRepository, EFLibroRepository>();
            services.AddTransient<IPrestitoRepository, EFPrestitoRepository>();
            services.AddTransient<IUtenteRepository, EFUtenteRepository>();

            // configurazione EF Core
            services.AddDbContext<BiblioContext>(options=> 
            {
                options.UseSqlServer(Configuration.GetConnectionString("AcademyG"));
            }
            );

            //configurazione swagger
            services.AddSwaggerGen(options=> {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //swagger middleware
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}");
            });

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
