using Microsoft.EntityFrameworkCore;
using RestAPIVend.Model.Context;
using AutoMapper;
using RestAPIVend.AutoMapperProfiles;

namespace RestAPIVend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<CompanyContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext")
            ?? throw new InvalidOperationException("Connection string 'CompanyContext' not found.")));
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
