using WebApplication3CURDWithDapperCore6MVC_Demo.DBContext;
using WebApplication3CURDWithDapperCore6MVC_Demo.Repositories;

var builder = WebApplication.CreateBuilder(args);
var token = builder.Configuration["AppSettings:token"];

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

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
	pattern: "{controller=TaskEntity}/{action=Index}/{id?}");

app.Run();
