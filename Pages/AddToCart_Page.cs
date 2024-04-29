using Playwright_Automation_Framework.Driver;

namespace PlayWrightCSharp.Pages;

public interface IAddToCart_Page
{
    Task ViewCart(string product_name, string price);
}

public class AddToCart_Page : IAddToCart_Page
{
    private readonly IPage _page;

    public AddToCart_Page(IPlaywrightDriver playwrightDriver)
    {
        _page = playwrightDriver.Page.Result;
    }

    #region Locators
    private ILocator _btnViewCartCheckout => _page.GetByRole(AriaRole.Link, new() { Name = "View cart and check out" });
    #endregion

    public async Task ViewCart(string product_name, string price)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = product_name }).First).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText(price, new() { Exact = true }).First).ToBeVisibleAsync();
        await _btnViewCartCheckout.ClickAsync();
    }
}