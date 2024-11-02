using AutoMapper.Internal;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Text.Json.Serialization;
using FoxDelivery.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace FoxDelivery.Api

{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins(Configuration.GetSection("Cors:Urls").GetChildren().Select(x => x.Value).ToArray())
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition")
                        .AllowAnyMethod();
                });
            });

            services.AddControllers()
                    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddEndpointsApiExplorer();

            services.AddApiVersioning(cfg =>
            {
                cfg.DefaultApiVersion = new ApiVersion(1, 0);
                cfg.AssumeDefaultVersionWhenUnspecified = true;
                cfg.ReportApiVersions = true;
                cfg.ApiVersionReader = new HeaderApiVersionReader("version");
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Fox Delivery API v1", Version = "v1" });
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Fox Delivery API v2", Version = "v2" });
            });

            services.AddDbContext<FoxDeliveryContext>(options =>
                 options.UseNpgsql(Configuration.GetConnectionString("PceDb"),
                 x => x.MigrationsAssembly(typeof(FoxDeliveryContext).Assembly.FullName)));

            services.AddScoped<FoxDeliveryContext>();

          //  services.AddSwagger(Configuration);
            services.AddSwaggerGen();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrador", policy => policy.RequireAuthenticatedUser()
                 .RequireAssertion(ctx => ctx.User.HasClaim(x => x.Type == "Admin" && x.Value == "Administrador")
             ));

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

        //    app.UseSwaggerExtension(() => MethodBase.GetCurrentMethod().DeclaringType.Assembly.GetManifestResourceStream("FoxDelivery.Api.wwwroot.index.html"));

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }

}
