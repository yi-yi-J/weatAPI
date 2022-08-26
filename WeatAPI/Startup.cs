


using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WeatAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //ConfigureServices方法,用来向容器中注册服务,注册好的服务可以在其他地方进行调用.
        public void ConfigureServices(IServiceCollection services)
        {
            //数据库连接字符串
            
            string conn = Configuration.GetConnectionString("WAPI");

            WeatAPImodels.WeatAPIEntities.WContext.ConStr = conn;
            //连接完字符串后要注册服务
            services.AddDbContext<WeatAPImodels.WeatAPIEntities.WContext>(options => { options.UseSqlServer(conn);});
            
            services.AddControllers();
            services.AddRouting();

            ///添加异常过滤
            services.AddControllers(option =>{
                option.Filters.Add(new ExceptionFilter());
                    });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //Configure方法,用来配置中间件管道,即如何响应http请求.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller=Home}/{action=Index}/{id?}");
                */
            });
        
        }
    }
}
