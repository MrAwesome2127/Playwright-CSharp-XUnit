using PlayWrightCSharp.Config;

namespace PlayWrightCSharp.Driver;

public class PlaywrightDriver
{
    private readonly Task<IBrowser> _browser;
    private readonly Task<IBrowserContext> _browserContext;
    private readonly TestSettings _testSettings;
    private readonly Task<IPage> _page;

    public PlaywrightDriver(TestSettings testSettings)
    {
        _testSettings = testSettings;
        _browser = Task.Run(InitializePlaywright);
        _browserContext = Task.Run(CreateBrowserContext);
        _page = Task.Run(CreatePageAsync);
    }

    public IPage Page => _page.Result;
    public IBrowser Browser => _browser.Result;

    private async Task<IBrowser> InitializePlaywright()
    {
        return await GetBrowser(_testSettings);
    }

    private async Task<IBrowserContext> CreateBrowserContext()
    {
        return await (await _browser).NewContextAsync();
    }

    private async Task<IPage> CreatePageAsync()
    {
        return await (await _browserContext).NewPageAsync();
    }

    private async Task<IBrowser> GetBrowser(TestSettings testSettings)
    {
        var playwrightDriver = await Playwright.CreateAsync();

        var browserOption = new BrowserTypeLaunchOptions
        {
            Channel = testSettings.Channel,
            Headless = testSettings.Headless,
            SlowMo = testSettings.SlowMo
        };

        return testSettings.DriverType switch
        {
            DriverType.Chromium => await playwrightDriver.Chromium.LaunchAsync(browserOption),
            DriverType.Chrome => await playwrightDriver["chrome"].LaunchAsync(browserOption),
            DriverType.Edge => await playwrightDriver.Chromium.LaunchAsync(browserOption),
            DriverType.Firefox => await playwrightDriver.Firefox.LaunchAsync(browserOption),
            _ => await playwrightDriver.Chromium.LaunchAsync(browserOption)
        };
    }
}