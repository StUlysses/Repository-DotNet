using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//ע��session
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddLogging(LoggingBuilder =>
{
    LoggingBuilder.AddLog4Net("configs/log4net.config");
});
//DIע��
builder.Services.AddSingleton<IWordService,WordService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//���þ�̬��Դ����
app.UseStaticFiles();
//����session
app.UseSession();
//����·��
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
