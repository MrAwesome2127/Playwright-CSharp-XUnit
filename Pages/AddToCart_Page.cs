namespace PlayWrightCSharp.Pages;

public class AddToCart_Page
{
    private readonly IPage _page;

    public AddToCart_Page(IPage page)
    {
        _page = page;
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