using Microsoft.EntityFrameworkCore;
using RestAPIVend.Model.Context;
using RestAPIVend.AutoMapperProfiles;
using RestAPIVend.Helpers;
using RestAPIVend.Services;

namespace RestAPIVend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Dodaj CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowNetworkClients",
                    policy =>
                    {
                        policy.WithOrigins("http://192.168.0.203:5283")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

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

            builder.Services.AddHttpClient<GeocodingService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // W³¹cz CORS przed innymi middleware, które mog¹ u¿ywaæ CORS (np. UseAuthorization)
            app.UseCors("AllowNetworkClients");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
