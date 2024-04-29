using Microsoft.Extensions.DependencyInjection;
using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;
using PlayWrightCSharp.Fixtures;
using PlayWrightCSharp.Pages;

namespace PlayWrightCSharp;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton(ConfigReader.ReadConfig())
            .AddScoped<IPlaywrightDriver, PlaywrightDriver>()
            .AddScoped<IPlaywrightDriverInitializer, PlaywrightDriverInitializer>()

            //Below is where you add URL direction and other settings based on neeed
            .AddScoped<ITestFixture, TestFixture>()

            //Below here you need to add you Interface from POM
            .AddScoped<IHome_Page, Home_Page>()
            .AddScoped<IProduct_Page, Product_Page>()
            .AddScoped<IAddToCart_Page, AddToCart_Page>()
            .AddScoped<ICheckout_Page, Checkout_Page>()
            ;

    }
}
