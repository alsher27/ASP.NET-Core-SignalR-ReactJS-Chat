using System;
using AlexChat.Models;
using AlexChat.Repository;
using AlexChat.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AlexChat
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddAutoMapper();

            //  services.AddReact();


            string connection = "Server=localhost\\SQLEXPRESS;Database=chat;Trusted_Connection=True;";
        
            services.AddDbContext<ChatContext>(options =>
                options.UseSqlServer(connection));

            services.AddScoped<IMessageRepo, MessageRepo>();
            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<IChatRepo, ChatRepo>();
            services.AddScoped<IChatService, ChatService>();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ChatContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
      
            return services.BuildServiceProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware();
            }
          
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chat");
            });


           // app.UseReact(config => { });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "api/{controller}/{action}/{id?}");
            });

        }
    }
}
