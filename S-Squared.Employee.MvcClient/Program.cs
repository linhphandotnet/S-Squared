using S_Squared.EmployeeClient;
using S_Squared.EmployeeClient.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = GetConfiguration();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddOptions<AppSetting>().Bind(configuration);

builder.Services.AddHttpClient("EmployeeClient")
        .SetHandlerLifetime(TimeSpan.FromMinutes(5));

builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IRoleService, RoleService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}
