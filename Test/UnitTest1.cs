using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;

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
    public async Task Test()
    {
        var page = await _driver.Page;
        await page.GotoAsync(_testSettings.ApplicationURL);
        await page.ClickAsync("text = Search");
    }

//    [Test]
//    public async Task Test1()
//    {
//        await Page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
//        await Page.GetByRole(AriaRole.Textbox, new() { Name = "Search games, hardware, news" }).FillAsync("LEgend of Zelda: Link's Awakening");
//        await Page.GetByLabel("The Legend of Zelda™: Link’s").ClickAsync();
//        await Page.GotoAsync("https://www.nintendo.com/us/store/products/the-legend-of-zelda-link-s-awakening-us/");
//        await Page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" }).ClickAsync();
//        await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "The Legend of Zelda™: Link’s" }).First).ToBeVisibleAsync();
//        await Expect(Page.GetByText("Qty:").First).ToBeVisibleAsync();
//        await Expect(Page.GetByText("$59.99", new() { Exact = true }).First).ToBeVisibleAsync();
//        await Expect(Page.GetByRole(AriaRole.Link, new() { Name = "View cart and check out" })).ToBeVisibleAsync();
//        await Page.GetByRole(AriaRole.Link, new() { Name = "View cart and check out" }).ClickAsync();
//        await Expect(Page.GetByText("Congratulations you've").Nth(1)).ToBeVisibleAsync();
//        await Expect(Page.Locator("#main").GetByText("1", new() { Exact = true })).ToBeVisibleAsync();
//        await Expect(Page.GetByText("$59.99", new() { Exact = true }).Nth(3)).ToBeVisibleAsync();
//        await Page.ScreenshotAsync(new PageScreenshotOptions
//        {
//            Path = "../../../Results/Nintedo.jpg"
//        });
//    }
}