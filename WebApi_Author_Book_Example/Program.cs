
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi_Author_Book_Example.AutoMappers;
using WebApi_Author_Book_Example.Data;
using WebApi_Author_Book_Example.Exceptions;
using WebApi_Author_Book_Example.Repository;
using WebApi_Author_Book_Example.Service;

namespace WebApi_Author_Book_Example
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("connstring"));
            });
            builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddTransient<IAuthorService, AuthorService>();
           // builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
            builder.Services.AddTransient<IBookService, BookService>();
           // builder.Services.AddTransient<IBookRepository, BookRepository>();
            builder.Services.AddTransient<IAuthorDetailsService, AuthorDetailsServicecs>();
            //builder.Services.AddTransient<IAuthorDetailsRepository, AuthorDetailsRepository>();
            builder.Services.AddControllers();
            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddExceptionHandler<ExcecptionHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseExceptionHandler(_=> {  });

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
