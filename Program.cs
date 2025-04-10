using Microsoft.EntityFrameworkCore;
using SecretHitler;
using SecretHitler.Hubs;
using SecretHitler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

var connectionString = builder.Configuration.GetConnectionString("MyAppCs");
builder.Services.AddDbContext<SHContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<UserService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapControllerRoute(
    name: "play",
    pattern: "{controller=Play}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<GameHub>("/gameHub");

app.Run();
