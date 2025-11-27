using SGA.Web.Clients;
using SGA.Web.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();


builder.Services.AddHttpClient<ILibroApiClient, LibroApiClient>(client =>
{
    var baseUrl = builder.Configuration["ApiSettings:BaseUrl"]
                  ?? "https://localhost:7149/";      

    client.BaseAddress = new Uri(baseUrl);
});


builder.Services.AddScoped<ILibroService, LibroService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
