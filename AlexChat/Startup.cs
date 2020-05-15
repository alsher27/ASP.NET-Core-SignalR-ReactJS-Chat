using System;
using AlexChatRepo.Entities;
using AlexChatRepo.Repository;
using AlexChatServices.Service;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AlexChatRepo;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;

namespace AlexChat
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.AddMemoryCache();

            string connection = Configuration.GetConnectionString("DefaultConnection");
        
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
     
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
#pragma warning disable CA1822 // Mark members as static
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("DefaultApi", "api/{controller}/{action}/{id?}");
            });

        }
#pragma warning restore CA1822 // Mark members as static
    }
}
