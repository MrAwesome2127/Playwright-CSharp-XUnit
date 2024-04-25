namespace PlayWrightCSharp.Pages;

public class Product_Page
{
    private readonly IPage _page;

    public Product_Page(IPage page)
    {
        _page = page;
    }

    #region Locators
    private ILocator _btnAddToCart => _page.GetByRole(AriaRole.Button, new() { Name = "Add to cart" });
    private ILocator _rdoPhysical => _page.GetByText("PhysicalThe Legend of Zelda™: Tears of the Kingdom", new() { Exact = true });
    #endregion

    public async Task AddToCart_PhysicalCopy()
    {
        await _rdoPhysical.ClickAsync();
        await _page.WaitForSelectorAsync("Add to cart" );
        await Assertions.Expect(_btnAddToCart).ToBeVisibleAsync();
        await _btnAddToCart.ClickAsync();
    }
}