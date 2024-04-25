namespace PlayWrightCSharp.Pages;

public class Checkout_Page
{
    private readonly IPage _page;

    public Checkout_Page(IPage page)
    {
        _page = page;
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
