using BirdCageShopRazorPage.Permission;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Repository.Implement;
using Repository.Interface;
using Repository.Mapper;

namespace BirdCageShopRazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IAuthorizationHandler, HasScopeHandler>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddRazorPages();

            builder.Services.AddAutoMapper(typeof(AutoMapperConfigure).Assembly);

            builder.Services.AddDbContext<BirdCageShopContext>();

            #region repository
            builder.Services.AddSingleton<ICageComponentRepository, CageComponentRepository>();
            builder.Services.AddSingleton<ICageImageRepository, CageImageRepository>();
            builder.Services.AddSingleton<ICageRepository, CageRepository>();
            builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
            builder.Services.AddSingleton<IComponentRepository, ComponentRepository>();
            builder.Services.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            builder.Services.AddSingleton<IOrderRepository, OrderRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            #endregion

            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", config =>
                {
                    config.Cookie.Name = "BirdCageShopCookie";
                    config.LoginPath = "/login";
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Customer", policy =>
                {
                    policy.Requirements.Add(new HasScopeRequirement("Customer Staff Admin"));
                });

                options.AddPolicy("Staff", policy =>
                {
                    policy.Requirements.Add(new HasScopeRequirement("Staff Admin"));
                });

                options.AddPolicy("Admin", policy =>
                {
                    policy.Requirements.Add(new HasScopeRequirement("Admin"));
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapPost("/logout", async (HttpContext context) =>
                {
                    await context.SignOutAsync();
                    context.Response.Redirect("/");
                });
            });

            app.Run();
        }
    }
}