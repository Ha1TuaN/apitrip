
using ApiKhachSan.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Configuration;

namespace ApiKhachSan
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
            builder.Services.AddDbContext<DuLichContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("MyConn")));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyCors",
                                  policy =>
                                  {
                                      policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                                  });
            });
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
                RequestPath = "/Uploads"
            });


            app.UseAuthorization();
            app.UseCors("MyCors");

            app.MapControllers();

            app.Run();
        }
    }
}
