
using Microsoft.EntityFrameworkCore;
using SurveyJS.Application.Abstractions.Repositories;
using SurveyJS.Application.Abstractions.Services;
using SurveyJS.Application.Abstractions.UnitOfWork;
using SurveyJS.Infrastructure.Data.Context;
using SurveyJS.Infrastructure.Data.Repositories;
using SurveyJS.Infrastructure.Data.UnitOfWork;
using SurveyJS.Infrastructure.Services;

namespace SurveyJS.Presentation
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
            //string? ConnectionString = builder.Configuration.GetConnectionString("ConnectionString");
            string? ConnectionString = builder.Configuration.GetValue<string>("ConnectionString");
            builder.Services.AddDbContext<SurveyDbContext>(option =>
            option.UseSqlServer(ConnectionString));
            #endregion



            #region Repos
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ISurveyRepo, SurveyRepo>();
            builder.Services.AddScoped<IPageRepo, PageRepo>();
            builder.Services.AddScoped<IChoiceRepo, ChoiceRepo>();
            builder.Services.AddScoped<IElementRepo, ElementRepo>();
            #endregion
            

            #region Services
            builder.Services.AddScoped<ISurveyService, SurveyService>();
            #endregion





            #region Add Cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            #endregion









            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
