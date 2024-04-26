using AutoFixture.Xunit2;
using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;
using PlayWrightCSharp.Model;
using PlayWrightCSharp.Pages;

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
        await home_Page.SearchForThisProduct("Games", "The Legend of Zelda™: Tears of the Kingdom";

        Product_Page product_Page = new Product_Page(page);
        await product_Page.AddToCart_PhysicalCopy("The Legend of Zelda™: Tears of the Kingdom");

        AddToCart_Page addToCart_Page = new AddToCart_Page(page);
        await addToCart_Page.ViewCart("The Legend of Zelda™: Tears of the Kingdom", "$69.99");

        Checkout_Page checkout_Page = new Checkout_Page(page);
        await checkout_Page.ValidateCartInformation("The Legend of Zelda™: Tears of the Kingdom", "$69.99");
    }

    [Theory] //In-line Data Driven
    [InlineData("Games", "The Legend of Zelda™: Breathe of the Wild", "$59.99")]
    [InlineData("Games", "The Legend of Zelda™: Tears of the Kingdom", "$69.99")]
    public async Task AddToCart_Game_LegendOfZelda_InlineDataDriven(string product_category, string product_name, string price)
    {
        var page = await _driver.Page;
        await page.GotoAsync(_testSettings.ApplicationURL);

        Home_Page home_Page = new Home_Page(page);
        await home_Page.SearchForThisProduct(product_category, product_name);

        Product_Page product_Page = new Product_Page(page);
        await product_Page.AddToCart_PhysicalCopy(product_name);

        AddToCart_Page addToCart_Page = new AddToCart_Page(page);
        await addToCart_Page.ViewCart(product_name, price);

        Checkout_Page checkout_Page = new Checkout_Page(page);
        await checkout_Page.ValidateCartInformation(product_name, price);
    }

    //If you are creating data for the same fields and do not want to concrete your data, use below! Autofixture will randomize the data every time you execute!
    //TODO: Under the "Model" folder, create a class file of the page you are needing data for.
    //
    //[Theory, AutoData]
    //public async Task CreateRandomUser(CreateRandomUser createRandomUser)
    //{
    //    var page = await _driver.Page;
    //    await page.GotoAsync(_testSettings.ApplicationURL);

        // await <POM>.<POM Method>(createRandomUser.username);
        // await <POM>.<POM Method>(createRandomUser.password);
        // await <POM>.<POM Method>(createRandomUser.first_name);
        // await <POM>.<POM Method>(createRandomUser.last_name);
    //}
}