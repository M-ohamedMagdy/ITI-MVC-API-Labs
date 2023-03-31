
using lab2.BL;
using lab2.DAL;
using Microsoft.EntityFrameworkCore;

namespace lab2.APIs
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

            var connectionString = builder.Configuration.GetConnectionString("ApiLab2");
            builder.Services.AddDbContext<myContext>(options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
            builder.Services.AddScoped<IDepartmentsRepo, DepartmentsRepo>();
            builder.Services.AddScoped<IDevelopersRepo, DevelopersRepo>();

            builder.Services.AddScoped<ITicketsManager, TicketsManager>();
            builder.Services.AddScoped<IDepartmentsManager, DepartmentsManager>();
            builder.Services.AddScoped<IDevelopersManager, DevelopersManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}