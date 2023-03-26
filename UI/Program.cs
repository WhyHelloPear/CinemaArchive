using Core.Application.Services;
using Domain.Contracts;
using Infrastructure.DataAccess.Contexts;
using Infrastructure.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CinemaArchiveDbContext>();


builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddAutoMapper( typeof( MappingConfiguration ).Assembly );
builder.Services.AddAutoMapper( typeof( DataAccessMappingConfig ).Assembly );
builder.Services.AddAutoMapper( typeof( UIMapper ).Assembly );

var app = builder.Build();

// Configure the HTTP request pipeline.
if( !app.Environment.IsDevelopment() ) {
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllers();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}" );

app.MapFallbackToFile( "index.html" );
;

app.Run();
