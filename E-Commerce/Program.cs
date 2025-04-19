
using System.Threading.Tasks;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using presistance;
using presistance.Data;
using Services.Abstractions;
using Services;
using E_Commerce.MiddleWares;

namespace E_Commerce
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);

            #region configire service

            builder.Services.AddScoped<IDBintializer, DBinitializer>();
            builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
            builder.Services.AddAutoMapper(typeof(Services.AssemblyRefrence).Assembly);
            builder.Services.AddScoped<IServiceManager, ServiceManager>();
            builder.Services.AddDbContext<storeContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            #endregion


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<GlobalExceptionHandlingMiddleWare>();

            await InitializedDbAsync(app);  

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            async Task InitializedDbAsync(WebApplication app)
            {
                using var Scope = app.Services.CreateScope();
                var dbinitializer = Scope.ServiceProvider.GetRequiredService<IDBintializer>();
                await dbinitializer.InitializeAsync();
            }
        }
    }
}
