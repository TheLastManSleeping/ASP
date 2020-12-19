using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SocialNetwork.Models;
using SocialNetwork.Repositories;

namespace SocialNetwork
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        } 

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            services.AddDbContext<ApplicationContext>(x => x.UseNpgsql(Config.ConnectionString), ServiceLifetime.Transient);
            
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            services.AddTransient<IRepository<Friend>, FriendRepository>();     
            services.AddScoped<IRepository<Message>, MessageRepository>(); 
            services.AddTransient<IRepository<Dialog>, DialogRepository>(); 
            services.AddSingleton<IError<int>, ErrorRepository>(); 
            services.AddControllersWithViews();
            services.AddSignalR();
            services.AddTransient<IImageService, ImageService>();
            services.AddLogging(opt =>
            {
                opt.AddConsole();
                opt.AddFile(Path.Combine(_webHostEnvironment.WebRootPath, "Logs/All.log"));
                opt.AddFile(Path.Combine(_webHostEnvironment.WebRootPath, "Logs/Error.log"), LogLevel.Error);
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();    // подключение аутентификации
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}