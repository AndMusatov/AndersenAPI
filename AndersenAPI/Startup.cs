using Domain.Core.Models;
using Domain.Interfaces.Generic;
using Domain.Interfaces.IInventory;
using Domain.Interfaces.IShoppingLists;
using Domain.Interfaces.Items;
using Domain.Interfaces.ItemToShoppingLists;
using Domain.Interfaces.UserOrders;
using Domain.Interfaces.Users;
using Infrastructure.Business.Inventories;
using Infrastructure.Business.Items;
using Infrastructure.Business.NewFolder;
using Infrastructure.Business.ShoppingLists;
using Infrastructure.Business.UserOrders;
using Infrastructure.Business.Users;
using Infrastructure.Data;
using Infrastructure.Data.Generic;
using Infrastructure.Data.Inventories;
using Infrastructure.Data.Items;
using Infrastructure.Data.ItemToShoppingLists;
using Infrastructure.Data.ShoppingLists;
using Infrastructure.Data.UserOrders;
using Infrastructure.Data.Users;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Services.Interfaces.Inventories;
using Services.Interfaces.Items;
using Services.Interfaces.ItemToShoppingLists;
using Services.Interfaces.ShoppingLists;
using Services.Interfaces.UserOrders;
using Services.Interfaces.Users;

namespace AndersenAPI
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

            services.AddRazorPages();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ShopContext>(options =>
                options.UseSqlServer(connection));

            services.AddControllersWithViews();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "test", Version = "v1" });
            });

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ShopContext>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {

                });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IShoppingListRepository, ShoppingListRepository>();
            services.AddScoped<IItemToShoppingListRepository, ItemToShoppingListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IUserOrdersRepository, UserOrderRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IShoppingListService, ShoppingListService>();
            services.AddTransient<IItemToShoppingService, ItemToShoppingService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IInventoryService, InventoryService>();
            services.AddTransient<IUserOrderService, UserOrderService>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "test");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


    }
}
