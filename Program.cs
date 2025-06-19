using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;

namespace VlammendVarkenBackend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ✅ Razor Views + API Controllers
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ✅ Databaseconfiguratie
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=Data/VlammendVarken.db"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // ✅ Middleware
        app.UseStaticFiles(); 
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        // ✅ Razor route (bijv. HomeController → Index.cshtml)
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // ✅ API Controllers blijven gewoon werken
        app.MapControllers();

        app.Run();
    }
}