
using BookWebApplication.DataAccess;
using BookWebApplication.Repository.Service;
using BookWebApplication.Server.Configuration;
using BookWebApplication.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace BookWebApplication.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            //builder.Services.AddDbContext<MainContext>(options =>
            //  options.UseSqlServer(connectionString));

            builder.ConfigureDatabase(); // databaseconfiguration
            //builder.Services.AddControllers()
                //.AddJsonOptions(options =>
                //{
                    //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
                    //options.JsonSerializerOptions.WriteIndented = true; // JSON chiroyli formatda bo‘lishi uchun
                //});

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
            builder.Services.AddScoped<MainContext>();

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
