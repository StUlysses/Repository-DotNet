using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interface;
using System;

namespace WePoem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();//session保存到内存
            services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(120);//session过期时间120分钟
            });//开启session
            services.AddSingleton<IPoemService, PoemServices>();//依赖注入
            services.AddSingleton<IUserService, UserServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseHttpsRedirection();//使用重定向
            app.UseStaticFiles();//外部可以访问静态文件
            app.UseSession();//使用session
            app.UseRouting();//使用路由

            app.UseAuthorization();//使用权限校验

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Poem}/{action=Index}/{id?}");
            });
        }
    }
}
