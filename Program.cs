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
    builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=Data/VlammendVarken.db"));

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
    
    // -------------------------------------------------------------------------------------------------------------- //
    
    // OK //
    app.MapControllerRoute(
      name: "gast.index",
      pattern: "gast/index",
      defaults: new { controller = "Home",         action = "Gast_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.allergenen.index",
      pattern: "gast/allergenen/index",
      defaults: new { controller = "Allergenen",   action = "Gast_Allergenen_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.voorgerechten.index",
      pattern: "gast/gerechten/voorgerechten/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Voorgerechten_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.hoofdgerechten.index",
      pattern: "gast/gerechten/hoofdgerechten/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Hoofdgerechten_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.hoofdgerechten.vlees.index",
      pattern: "gast/gerechten/hoofdgerechten/vlees/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Hoofdgerechten_Vlees_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.hoofdgerechten.vis.index",
      pattern: "gast/gerechten/hoofdgerechten/vis/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Hoofdgerechten_Vis_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.hoofdgerechten.vegetarisch.index",
      pattern: "gast/gerechten/hoofdgerechten/vegetarisch/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Hoofdgerechten_Vegetarisch_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.hoofdgerechten.edit",
      pattern: "gast/gerechten/hoofdgerechten/edit",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Hoofdgerechten_Edit" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.gerechten.nagerechten.index",
      pattern: "gast/gerechten/nagerechten/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Nagerechten_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.bestellingen.overzicht.index",
      pattern: "gast/bestellingen/overzicht/index",
      defaults: new { controller = "Bestellingen", action = "Gast_Bestellingen_Overzicht_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "gast.bestellingen.tafels.index",
      pattern: "gast/bestellingen/tafels/index",
      defaults: new { controller = "Bestellingen", action = "Gast_Bestellingen_Tafels_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "personeel.bestellingen.overzicht.index",
      pattern: "personeel/bestellingen/overzicht/index",
      defaults: new { controller = "Bestellingen", action = "Personeel_Bestellingen_Overzicht_Index" });
    
    // OK //
    app.MapControllerRoute(
      name: "personeel.bestellingen.details.index",
      pattern: "personeel/bestellingen/details/index",
      defaults: new { controller = "Bestellingen", action = "Personeel_Bestellingen_Details_Index" });
    
    // -------------------------------------------------------------------------------------------------------------- //      
    app.MapControllers();
    app.Run();
  }
}
