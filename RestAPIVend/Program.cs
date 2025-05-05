using Microsoft.EntityFrameworkCore;
using RestAPIVend.Model.Context;
using AutoMapper;
using RestAPIVend.AutoMapperProfiles;
using RestAPIVend.Helpers;

namespace RestAPIVend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<CompanyContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyContext")
            ?? throw new InvalidOperationException("Connection string 'CompanyContext' not found.")));

            builder.Services.AddSwaggerGen(c =>
            {
                c.DocumentFilter<HideInternalModelsDocumentFilter>();
            });

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
