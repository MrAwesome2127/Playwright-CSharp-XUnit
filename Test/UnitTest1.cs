using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;
using PlayWrightCSharp.Fixtures;
using PlayWrightCSharp.Model;
using PlayWrightCSharp.Pages;

namespace PlayWrightCSharp.Test;

public class Tests
{
    private readonly ITestFixture _testFixture;
    private readonly IHome_Page _home_Page;
    private readonly IProduct_Page _product_Page;
    private readonly IAddToCart_Page _addToCart_Page;
    private readonly ICheckout_Page _checkout_Page;

    public Tests(ITestFixture testFixture, IHome_Page home_Page, IProduct_Page product_Page, IAddToCart_Page addToCart_Page, ICheckout_Page checkout_Page)
    {
        _testFixture = testFixture;
        _home_Page = home_Page;
        _product_Page = product_Page;
        _addToCart_Page = addToCart_Page;
        _checkout_Page = checkout_Page;
    }

    [Fact]
    public async Task AddToCart_Game_LegendOfZelda()
    {
        //Arrange
        await _testFixture.NavigateToURL();

        //Act
        await _home_Page.SearchForThisProduct("Games", "The Legend of Zelda™: Tears of the Kingdom");
        await _testFixture.TakeScreenShot("C:\\Users\\Coach\\GitHub\\Playwright-CSharp-NUnit\\Results");

        await _product_Page.AddToCart_PhysicalCopy("The Legend of Zelda™: Tears of the Kingdom");
        await _addToCart_Page.ViewCart("The Legend of Zelda™: Tears of the Kingdom", "$69.99");

        //Assert
        await _checkout_Page.ValidateCartInformation("The Legend of Zelda™: Tears of the Kingdom", "$69.99");
        await _testFixture.TakeScreenShot("C:\\Users\\Coach\\GitHub\\Playwright-CSharp-NUnit\\Results");
    }

    [Theory] //In-line Data Driven
    [InlineData("Games", "The Legend of Zelda™: Breathe of the Wild", "$59.99")]
    [InlineData("Games", "The Legend of Zelda™: Tears of the Kingdom", "$69.99")]
    public async Task AddToCart_Game_LegendOfZelda_InlineDataDriven(string product_category, string product_name, string price)
    {
        //Arrange
        await _testFixture.NavigateToURL();

        //Act
        await _home_Page.SearchForThisProduct(product_category, product_name);
        await _testFixture.TakeScreenShot("C:\\Users\\Coach\\GitHub\\Playwright-CSharp-NUnit\\Results");

        await _product_Page.AddToCart_PhysicalCopy(product_name);
        await _addToCart_Page.ViewCart(product_name, price);

        //Assert
        await _checkout_Page.ValidateCartInformation(product_name, price);
        await _testFixture.TakeScreenShot("C:\\Users\\Coach\\GitHub\\Playwright-CSharp-NUnit\\Results");
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