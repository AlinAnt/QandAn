using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QandAn.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static QandAn.Areas.Identity.Pages.Account.RegisterModel;
using Microsoft.AspNetCore.Identity.UI.Services;
using QandAn.Services;

namespace QandAn
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>( )
                .AddRoles<IdentityRole>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication().AddFacebook(facebookOptions =>  
            {  
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];  
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];  
            });
            
            services.AddAuthentication().AddTwitter(twitterOptions => {  
                twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];  
                twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];  
            });  

            
            services.AddTransient<StackService>();
            services.AddScoped<DatabaseService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<RolesImputerService>();
            services.AddHostedService<ContentService>();
            services.AddScoped<IScopedProcessingService, ScopedProcessingService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Error","?code={0}");
                app.UseExceptionHandler("/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
            app.UseAuthentication();
            app.UseSignalR(routes =>
            {
                routes.MapHub<AnswerHub>("/answerHub");
            });
        
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=QuestionList}/{action=Index}/{id?}");
            });
        }


    }
}
