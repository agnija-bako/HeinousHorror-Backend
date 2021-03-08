using System.Text;
using System.Transactions;
using heinousHorror.Authentication;
using heinousHorror.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace heinousHorror
{
    public class Startup
    {
        private string _jwtSecretKey = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            StaticConfiguration = configuration;
            ApiHelper.InitializeClients();
        }

        public static string Db { get; set; }

        public IConfiguration Configuration { get; }

        public static IConfiguration StaticConfiguration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<HeinousHorrorContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("HeinousHorrorConnection")));
            Db = Configuration.GetConnectionString("HeinousHorrorConnection");
            services.AddControllers();
            _jwtSecretKey = Configuration["JwtSecretKey"];
            //Configure Jwt pipeline
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;

                //Use key defined while validating the token to decrypt and ensure the user is authenticated
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            
            //Configure Authentication manager
            services.AddSingleton<IJwtAuthenticationManger>(new JwtAuthenticationManager(_jwtSecretKey));

            //Enable cors for origin
            services.AddCors(c =>
            {
                c.AddDefaultPolicy(builder=>builder.WithOrigins("http://localhost:3000"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
           
        }
    }
}