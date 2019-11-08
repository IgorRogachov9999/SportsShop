using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BuisnessLayer.Repositories;
using BuisnessLayer.Models;
using DataLayer.EFRepositories;
using BuisnessLayer.Services;
using BuisnessLayer;
using DataLayer;

namespace SportsStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportStoreProducts:ConnectionString"],
                    b => b.MigrationsAssembly("DataLayer")));

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:SportStoreIdentity:ConnectionString"],
                    b => b.MigrationsAssembly("DataLayer")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<AccountService, AccountService>();
            services.AddTransient<CartService, CartService>();
            services.AddTransient<CategoryService, CategoryService>();
            services.AddTransient<OrderService, OrderService>();
            services.AddTransient<ProductServcie, ProductServcie>();

            services.AddCors();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseCors(MyAllowSpecificOrigins);

            /*app.UseCors(
                options => options.WithOrigins("http://localhost:4200", "https://reqbin.com/").AllowAnyMethod()
            );*/
            app.UseCors(builder => builder.AllowAnyOrigin());
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: null,
                   template: "{category}/Page{productPage:int}",
                   defaults: new { controller = "Product", action = "List" }
                );
                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );
                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    }
                );
                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new
                    {
                        controller = "Product",
                        action = "List",
                        productPage = 1
                    });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });

            IdentitySeedData.EnsurePopulated(app);

        }
    }
}
