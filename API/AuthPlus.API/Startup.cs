using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsultaUsuarios;
using Context;
using InicioSesion;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RegistroInicio;

namespace AuthPlus.API
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

            services.AddControllers();
            services.AddScoped<ValidarExistenciaUsuario>();
            services.AddScoped<ValidarInformacionUsuario>();
            services.AddScoped<ValidarLogsRecientesUsuario>();
            services.AddScoped<ValidarLogsTotalesUsuario>();
            services.AddScoped<IniciarSesion>();
            services.AddScoped<RegistrarLog>();
            services.AddScoped<AsignarRol>();
            services.AddScoped<RegistrarUsuarios>();
            services.AddSingleton<FakeDbContext>();

            services.AddCors(options => 
                options.AddPolicy("DefaultPolicy", Builder => 
                    Builder.WithOrigins("http://localhost:8100")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                )
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthPlus.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthPlus.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors("DefaultPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
