using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using silverkissen.Models; 

namespace silverkissen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string originString = "silverkissen_cors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(originString, builder =>
                {
                    builder.WithOrigins(Configuration.GetSection("Cors:Prod").Value,
                                        Configuration.GetSection("Cors:Test").Value)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

            var secret = Configuration.GetSection("Auth:Secret").Value; 
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
#if DEBUG
            services.AddDbContext<SilverkissenContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestConnection")));
#else
            services.AddDbContext<SilverkissenContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProdConnection")));
#endif
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "martin",
                    ValidAudience = "readers",
                    IssuerSigningKey = symmetricSecurityKey
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(originString);
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            
        }
    }
}
