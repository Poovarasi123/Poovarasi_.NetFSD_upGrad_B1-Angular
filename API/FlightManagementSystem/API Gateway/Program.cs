using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace API_Gateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load Ocelot config
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            // Add Ocelot
            builder.Services.AddOcelot();

            var app = builder.Build();

            // Use Ocelot middleware
            await app.UseOcelot();

            app.Run();
        }
    }
}