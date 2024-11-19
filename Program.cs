using Havit.Blazor.Components.Web;
using HavitGridBug.Components;
using HavitGridBug.Data;
using Microsoft.EntityFrameworkCore;
using Havit.Blazor.Components.Web;
using HavitGridBug.Data.Services;

namespace HavitGridBug
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddHxServices();

            var connection = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddDbContext<DataContext>(
                options => options.UseSqlServer(connection)
            );

            builder.Services.AddScoped<CustomerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
