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
    
    app.MapControllerRoute(
      name: "gast.allergenen.index",
      pattern: "gast/allergenen/index",
      defaults: new { controller = "Allergenen",   action = "Gast_Allergenen_Index" });
    
    app.MapControllerRoute(
      name: "gast.gerechten.index",
      pattern: "gast/gerechten/{gerechtSoort}/index",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Index" });
    
    app.MapControllerRoute(
      name: "gast.gerechten.edit",
      pattern: "gast/gerechten/{gerechtSoort}/{gerechtId}/edit",
      defaults: new { controller = "Gerechten",    action = "Gast_Gerechten_Index" });
    
    app.MapControllerRoute(
      name: "gast.bestellingen.overzicht.index",
      pattern: "gast/bestellingen/overzicht/index",
      defaults: new { controller = "Bestellingen", action = "Gast_Bestellingen_Overzicht_Index" });
    
    app.MapControllerRoute(
      name: "gast.bestellingen.tafels.index",
      pattern: "gast/bestellingen/tafels/index",
      defaults: new { controller = "Bestellingen", action = "Gast_Bestellingen_Tafels_Index" });
    
    app.MapControllerRoute(
      name: "personeel.bestellingen.overzicht.index",
      pattern: "personeel/bestellingen/overzicht/index",
      defaults: new { controller = "Bestellingen", action = "Personeel_Bestellingen_Overzicht_Index" });
    
    app.MapControllerRoute(
      name: "personeel.bestellingen.details.index",
      pattern: "personeel/bestellingen/details/{bestellingId}/index",
      defaults: new { controller = "Bestellingen", action = "Personeel_Bestellingen_Details_Index" });
    
    app.MapControllers();
    app.Run();
  }
}
