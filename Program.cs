// Program.cs
using EvalApi.Src.Core.Repositories;
using EvalApi.Src.Core.Repositories.User;
using EvalApi.Src.Core.Services.User;
using EvalApi.Src.Core.Repositories.Post;
using EvalApi.Src.Core.Services.Post;
using Microsoft.EntityFrameworkCore;

namespace EvalApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=Data/database.db");
        });

        // Add application services to the container.
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        // Add post services to the container.
        builder.Services.AddScoped<IPostRepository, PostRepository>();
        builder.Services.AddScoped<IPostService, PostService>();

        // Add framework services.
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