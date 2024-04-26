namespace PlayWrightCSharp.Pages;

public class Home_Page
{
    private readonly IPage _page;

    public Home_Page(IPage page)
    {
        _page = page;
    }

    #region Locators
    private ILocator _btnSearch => _page.GetByRole(AriaRole.Button, new() { Name = "Search" });
    private ILocator _btnStore => _page.GetByRole(AriaRole.Button, new() { Name = "My Nintendo Store" });
    private ILocator _ddlMerchandise => _page.GetByTestId("dropdownMenu").GetByRole(AriaRole.Link, new() { Name = "Merchandise" });
    private ILocator _ddlSearchCategories => _page.Locator("form").Filter(new() { HasText = "SearchAll categories" }).GetByTestId("ChevronDownIcon");
    private ILocator _fldSearch => _page.GetByTestId("desktop-nav").GetByPlaceholder("Search games, hardware, news");
    #endregion

    public async Task SearchForThisProduct(string product_category, string product_name)
    {
        await _ddlSearchCategories.ClickAsync();
        await _page.GetByRole(AriaRole.Option, new() { Name = product_category }).ClickAsync();
        await _btnSearch.ClickAsync();
        await _fldSearch.FillAsync(product_name);
        await _page.GetByLabel(product_name, new() { Exact = true }).ClickAsync();
    }
}
