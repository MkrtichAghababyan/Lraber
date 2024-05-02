
using NewsPaperAPI.Models;
using NewsPaperAPI.Services.ForAdminInterfaces;
using NewsPaperAPI.Services.ForAdminServices;

namespace NewsPaperAPI
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
            //Service Connections
            builder.Services.AddScoped<IArticleService,ArticleService>();
            //Db Connection
            builder.Services.AddSqlServer<NewsPaperContext>(builder.Configuration.GetConnectionString("Connect"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.1j
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}