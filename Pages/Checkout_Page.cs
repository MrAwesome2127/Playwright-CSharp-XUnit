using Playwright_Automation_Framework.Driver;

namespace PlayWrightCSharp.Pages;

public interface ICheckout_Page
{
    Task ValidateCartInformation(string product_name, string price);
}

public class Checkout_Page : ICheckout_Page
{
    private readonly IPage _page;

    public Checkout_Page(IPlaywrightDriver playwrightDriver)
    {
        _page = playwrightDriver.Page.Result;
    }

    #region Locators
    private ILocator _txtBanner_FreeShipping => _page.GetByText("Congratulations you've qualified for free shipping!").Nth(1);
    private ILocator _txtGameTitle => _page.Locator("a").Filter(new() { HasText = "The Legend of Zelda™: Tears of the Kingdom" }).Nth(2);
    private ILocator _txtFreeShipping => _page.GetByText("ShippingFree");
    private ILocator _btnLoginToCheckout => _page.GetByRole(AriaRole.Button, new() { Name = "Proceed to secure checkout" });
    #endregion

    public async Task ValidateCartInformation(string product_name, string price)
    {
        await Assertions.Expect(_txtBanner_FreeShipping).ToBeVisibleAsync();
        await Assertions.Expect(_page.Locator("a").Filter(new() { HasText = product_name }).Nth(2)).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText(price, new() { Exact = true }).Nth(1)).ToBeVisibleAsync();
        await Assertions.Expect(_txtFreeShipping).ToBeVisibleAsync();
        await Assertions.Expect(_btnLoginToCheckout).ToBeVisibleAsync();
    }
}
