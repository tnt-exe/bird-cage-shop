using Repository.Implement;
using Repository.Interface;
using Repository.Mapper;
using Repository.UnitOfWork;

namespace BirdCageShopRazorPage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSession();
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

            builder.Services.AddSingleton<IUnitOfWork, IUnitOfWork>();
            #endregion

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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}