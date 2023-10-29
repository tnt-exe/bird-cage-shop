using BirdCageShopRazorPage.Permission;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Repository.Implement;
using Repository.Interface;
using Repository.Mapper;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

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

            app.UseMiddleware<GlobalExceptionMiddleware>();

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



public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Could not process a request on machine {Machine}. TraceId: {TraceId}",
                Environment.MachineName,
                Activity.Current?.Id);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var error = new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error: " + exception.Message
        };

        await context.Response.WriteAsync(error.ToString());
    }

    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}