
using lab3.API.Heplers;
using lab3.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace lab3.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region Context

            var connectionString = builder.Configuration.GetConnectionString("APIlab3DB");
            builder.Services.AddDbContext<PersonsContext>(options => options.UseSqlServer(connectionString));

            #endregion

            #region Injection

            builder.Services.AddScoped<IHelpers, Helpers>();

            #endregion

            #region Identity Manager

            builder.Services.AddIdentity<Person, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;

                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<PersonsContext>();

            #endregion

            #region Authentication

            var securityKey = builder.Configuration.GetSecurityKeyExt();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Schema1";
                options.DefaultChallengeScheme = "Schema1";
            })
                .AddJwtBearer("Schema1", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = securityKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AllowAdminsOnly",
                    builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));
                options.AddPolicy("AllowUsers&Admins",
                    builder => builder.RequireClaim(ClaimTypes.Role, "User", "Admin"));
            });

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}