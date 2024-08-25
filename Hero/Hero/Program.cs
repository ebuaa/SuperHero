using hero_csharp.Data;
using hero_csharp.Services.HeroService;
using hero_csharp.Services.SchoolService;
using hero_csharp.Services.SuperPowerService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration du service DbContext pour utiliser SQL Server
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=LAPTOP-MEVMBK22\\MSSQLSERVER02;Database=hero;Integrated Security=True;Encrypt=False")));

// Enregistrement des services
builder.Services.AddScoped<IHeroService, HeroService>();
builder.Services.AddScoped<ISchoolService, SchoolService>();

// Ajout de Swagger pour la documentation de l'API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Cette ligne est nécessaire pour configurer Swagger

// Ajout des services pour les contrôleurs avec des vues Razor
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuration du pipeline de gestion des requêtes HTTP
if (app.Environment.IsDevelopment())
{
    // Activer Swagger pour la documentation de l'API en développement
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Configuration du routage par défaut de l'application
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Hero}/{action=Create}/{id?}");

app.Run();