using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Nozama.Api.Providers;
using Nozama.Core.Providers;
using Nozama.Core.Services;
using Nozama.Persistence.Contexts;
using Nozama.Services;

namespace Nozama.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

            // Authentication

            // Create JwtAuthProvider to access appsettings.{env}.json
            var jwtAuth = Configuration.GetSection("JwtAuth").Get<JwtAuthProvider>();

            // Add JwtAuthProvider to services
            services.AddSingleton<ISecretKeyProvider>(jwtAuth);

            // Add and configure jwt authentication service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(jwtAuth.KeyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // Add DbContext (Use in-memory database for now)
            services.AddDbContext<NozamaContext>(o => o.UseInMemoryDatabase("Nozama"));

            // Add other services
            services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error");

            app.UseRouting();

            app.UseCors(b =>
            {
                b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
