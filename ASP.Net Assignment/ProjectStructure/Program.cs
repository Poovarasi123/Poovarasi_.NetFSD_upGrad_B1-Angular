namespace ProjectStructure
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); // ✅ ADD THIS

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession(); // ✅ ADD THIS (VERY IMPORTANT)

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
