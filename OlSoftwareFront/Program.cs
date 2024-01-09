var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromMinutes(30); // Establecer el tiempo de expiración de la sesión
});

builder.WebHost.UseUrls("http://*:1435");
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
app.MapControllerRoute(name: "Login",
                pattern: "Login",
                defaults: new { controller = "Login", action = "Index" });

app.MapControllerRoute(name: "Ingresar",
                pattern: "Ingresar",
                defaults: new { controller = "Login", action = "Login" });
app.MapControllerRoute(name: "Dashboard",
                pattern: "Dashboard",
                defaults: new { controller = "Dashboard", action = "Index" });
app.MapControllerRoute(name: "Aspirantes",
                pattern: "Aspirantes",
                defaults: new { controller = "Aspirante", action = "Index" });
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
