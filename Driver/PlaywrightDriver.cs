using PlayWrightCSharp.Config;

namespace PlayWrightCSharp.Driver;

public class PlaywrightDriver
{
    private readonly Task<IBrowser> _browser;
    private readonly Task<IBrowserContext> _browserContext;
    private readonly TestSettings _testSettings;
    private readonly IPlaywrightDriverInitializer _playwrightDriverInitializer;
    private readonly Task<IPage> _page;

    public PlaywrightDriver(TestSettings testSettings, IPlaywrightDriverInitializer playwrightDriverInitializer)
    {
        _testSettings = testSettings;
        _playwrightDriverInitializer = playwrightDriverInitializer;
        _browser = Task.Run(InitializePlaywright);
        _browserContext = Task.Run(CreateBrowserContext);
        _page = Task.Run(CreatePageAsync);
    }

    public IPage Page => _page.Result;
    public IBrowser Browser => _browser.Result;
    public IBrowserContext BrowserContext => _browserContext.Result;

    private async Task<IBrowser> InitializePlaywright()
    {
        return _testSettings.DriverType switch
        {
            DriverType.Chromium => await _playwrightDriverInitializer.GetChromiumDriver(_testSettings),
            DriverType.Chrome => await _playwrightDriverInitializer.GetChromeDriver(_testSettings),
            DriverType.Edge => await _playwrightDriverInitializer.GetEdgeDriver(_testSettings),
            DriverType.Firefox => await _playwrightDriverInitializer.GetFirefoxDriver(_testSettings),
            _ => await _playwrightDriverInitializer.GetChromiumDriver(_testSettings)
        };
    }

    private async Task<IBrowserContext> CreateBrowserContext()
    {
        return await (await _browser).NewContextAsync();
    }

    private async Task<IPage> CreatePageAsync()
    {
        return await (await _browserContext).NewPageAsync();
    }
}