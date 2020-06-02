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
            services.AddDistributedMemoryCache();//session���浽�ڴ�
            services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(120);//session����ʱ��120����
            });//����session
            services.AddSingleton<IPoemService, PoemServices>();//����ע��
            services.AddSingleton<IUserService, UserServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseHttpsRedirection();//ʹ���ض���
            app.UseStaticFiles();//�ⲿ���Է��ʾ�̬�ļ�
            app.UseSession();//ʹ��session
            app.UseRouting();//ʹ��·��

            app.UseAuthorization();//ʹ��Ȩ��У��

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Poem}/{action=Index}/{id?}");
            });
        }
    }
}
