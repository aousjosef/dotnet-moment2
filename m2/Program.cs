var builder = WebApplication.CreateBuilder(args);

//aktiverar MVC
builder.Services.AddControllersWithViews();


var app = builder.Build();


//wwwroot
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

//app.MapGet("/", () => "hello worlds!!");

app.Run();
