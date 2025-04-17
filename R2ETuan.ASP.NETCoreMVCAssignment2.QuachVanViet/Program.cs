using ASP.NETCoreMVCAssignment1.QuachVanViet.Services;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Repository;
using R2ETuan.ASP.NETCoreMVCAssignment1.QuachVanViet.Services;

namespace ASP.NETCoreMVCAssignment1.QuachVanViet
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IPersonService, PersonService>();
            builder.Services.AddScoped<IPersonFilterService, PersonFilterService>();
            builder.Services.AddSingleton<IPersonRepository, PersonRepository>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "NashTech",
                pattern: "NashTech/{controller=Rookies}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
