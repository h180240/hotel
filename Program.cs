using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Hotel.Data;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
namespace Hotel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HotelContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext") ?? throw new InvalidOperationException("Connection string 'HotelContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure Entity Framework and Identity
            services.AddDbContext<HotelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("HotelContext")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<HotelContext>()
                .AddDefaultTokenProviders();

            services.AddControllersWithViews();
        }
    }
}
