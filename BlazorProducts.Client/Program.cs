using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using BlazorProducts.Client.HttpRepository;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BlazorProducts.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));

            builder.Services.AddHttpClient("ProductsAPI",
                cl =>
                {
                    new Uri("https://localhost:5011/api/");
                });

            builder.Services.AddScoped(
                sp => sp.GetService<IHttpClientFactory>().CreateClient("ProductsAPI"));

            builder.Services.AddScoped<IProductHttpRepository, ProductHttpRepository>();

            await builder.Build().RunAsync();
        }
    }
}