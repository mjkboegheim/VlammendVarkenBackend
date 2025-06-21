using Microsoft.EntityFrameworkCore;
using VlammendVarkenBackend.Data;

namespace VlammendVarkenBackend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllersWithViews();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=Data/VlammendVarken.db"));

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.UseStaticFiles(); 
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        
        app.MapControllerRoute(
            name: "voorgerechten.index",
            pattern: "gerechten/voorgerechten",
            defaults: new { controller = "Gerecht", action = "Voorgerecht_Index" });

        app.MapControllerRoute(
            name: "hoofdgerechten.index",
            pattern: "gerechten/hoofdgerechten",
            defaults: new { controller = "Gerecht", action = "Hoofdgerecht_Index" });

        app.MapControllerRoute(
            name: "hoofdgerechten.vlees.index",
            pattern: "gerechten/hoofdgerechten/vlees",
            defaults: new { controller = "Gerecht", action = "Vleesgerecht_Index" });

        app.MapControllerRoute(
            name: "hoofdgerechten.vis.index",
            pattern: "gerechten/hoofdgerechten/vis",
            defaults: new { controller = "Gerecht", action = "Visgerecht_Index" });

        app.MapControllerRoute(
            name: "hoofdgerechten.vegetarisch.index",
            pattern: "gerechten/hoofdgerechten/vegetarisch",
            defaults: new { controller = "Gerecht", action = "Vegetarisch_Index" });

        app.MapControllerRoute(
            name: "hoofdgerechten.edit",
            pattern: "gerechten/hoofdgerechten/edit",
            defaults: new { controller = "Gerecht", action = "Hoofdgerecht_Edit" });

        app.MapControllerRoute(
            name: "nagerechten.index",
            pattern: "gerechten/nagerechten",
            defaults: new { controller = "Gerecht", action = "Nagerecht_Index" });

        app.MapControllerRoute(
            name: "bestelling.overzicht.gast.index",
            pattern: "bestelling/overzicht",
            defaults: new { controller = "Bestelling", action = "Overzicht_Gast_Index" });

        app.MapControllerRoute(
            name: "bestelling.tafels.index",
            pattern: "bestelling/tafels",
            defaults: new { controller = "Bestelling", action = "Tafels_Index" });

        app.MapControllerRoute(
            name: "bestelling.overzicht.chefkok.index",
            pattern: "bestelling/lopend/overzicht",
            defaults: new { controller = "Bestelling", action = "Overzicht_Chefkok_Index" });

        app.MapControllerRoute(
            name: "bestelling.details",
            pattern: "bestelling/details",
            defaults: new { controller = "Bestelling", action = "Details_Index" });

        app.MapControllerRoute(
            name: "allergie.index",
            pattern: "allergie",
            defaults: new { controller = "Allergie", action = "Index" });

        app.MapControllerRoute(
            name: "home",
            pattern: "{controller=Gerecht}/{action=Index}");

        app.MapControllers();

        app.Run();
    }
}

