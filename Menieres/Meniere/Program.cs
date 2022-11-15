using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//注册session
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddLogging(LoggingBuilder =>
{
    LoggingBuilder.AddLog4Net("configs/log4net.config");
});
//DI注入
builder.Services.AddSingleton<IWordService,WordService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//启用静态资源访问
app.UseStaticFiles();
//启用session
app.UseSession();
//启用路由
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
