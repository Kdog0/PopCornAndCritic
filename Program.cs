using Microsoft.EntityFrameworkCore;
using TarefasSistemas.Data;
using TarefasSistemas.Repositorios;
using TarefasSistemas.Repositorios.Interfaces;

namespace Tarefas
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

            var stringConnection = builder.Configuration.GetConnectionString("DataBase");

            builder.Services.AddEntityFrameworkSqlServer()
                .AddDbContext<TarefasDoSistemaDbContext>(
                    options => options.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection))
                );

            builder.Services.AddScoped<IUsuariosRepositorio, UsuarioRepositorios>();

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