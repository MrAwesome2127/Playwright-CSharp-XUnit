using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;
using PlayWrightCSharp.Pages;
using System.Diagnostics;

namespace PlayWrightCSharp.Test;

public class Tests : IClassFixture<PlaywrightDriverInitializer>
{
    private readonly PlaywrightDriver _driver;
    private readonly PlaywrightDriverInitializer _playwrightDriverInitializer;
    private readonly TestSettings _testSettings;

    
    public Tests(PlaywrightDriverInitializer playwrightDriverInitializer)
    {
        _testSettings = ConfigReader.ReadConfig();
        _playwrightDriverInitializer = playwrightDriverInitializer;
        _driver = new PlaywrightDriver(_testSettings, _playwrightDriverInitializer);
    }

    [Fact]
    public async Task AddToCart_Game_LegendOfZelda()
    {
        var page = await _driver.Page;
        await page.GotoAsync(_testSettings.ApplicationURL);

        Home_Page home_Page = new Home_Page(page);
        await home_Page.SearchForThisProduct("Games", "The Legend of Zelda™: Tears of the Kingdom");

        Product_Page product_Page = new Product_Page(page);
        await product_Page.AddToCart_PhysicalCopy();

        AddToCart_Page addToCart_Page = new AddToCart_Page(page);
        await addToCart_Page.ViewCart("The Legend of Zelda™: Tears of the Kingdom", "$69.99");

        Checkout_Page checkout_Page = new Checkout_Page(page);
        await checkout_Page.ValidateCartInformation("The Legend of Zelda™: Tears of the Kingdom", "$69.99");
    }
}