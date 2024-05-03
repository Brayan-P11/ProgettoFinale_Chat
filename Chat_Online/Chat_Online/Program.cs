
using Chat_Online.Models;
using Chat_Online.Repositories;
using Chat_Online.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Chat_Online
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

            #region Configurazione Scoped
            //----------------
            builder.Services.AddDbContext<DbChatOnlineContext>(
              options => options.UseSqlServer(
                  builder.Configuration.GetConnectionString("DefaultConnection")
                  )
              );

            builder.Services.AddScoped<MessaggioRepo>();
            builder.Services.AddScoped<MessaggioService>();
            //builder.Services.AddScoped<StanzaRepo>();
            //builder.Services.AddScoped<StanzaService>();
            builder.Services.AddScoped<UtenteRepo>();
            builder.Services.AddScoped<UtenteService>();

            //---------------
            #endregion

            #region Authorization

            builder.Services.AddAuthentication()
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = "Team",
                   ValidAudience = "Utenti",
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key_your_super_secret_key"))
               };
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


            app.UseAuthorization();
            app.UseAuthentication();

            app.UseCors(builder =>
             builder
             .WithOrigins("*")
             .AllowAnyMethod()
             .AllowAnyHeader());



            app.MapControllers();

            app.Run();
        }
    }
}
