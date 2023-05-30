
using ContratosToyyoda.Data;
using ContratosToyyoda.Data.Services;
using ContratosToyyoda.Helpers;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xceed.Document.NET;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    _ = options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));

});

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option => {
        option.LoginPath = "/Access/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);

    });


// Add services to the container.


builder.Services.AddControllersWithViews();

//services configuration
builder.Services.AddScoped<IUsuariosService, UsuariosService>();
builder.Services.AddScoped<IPaisesService, PaisesService>();
builder.Services.AddScoped<IContratosService, ContratosService>();
builder.Services.AddScoped<IApoderadosService, ApoderadosService>();
builder.Services.AddScoped<HelperMail>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(    );
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Access}/{action=Login}/{id?}");



app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    Secure = CookieSecurePolicy.Always
});


AppDbInitializer.Seed(app);
app.Run();
