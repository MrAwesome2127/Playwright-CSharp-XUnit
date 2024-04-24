using PlayWrightCSharp.Config;

namespace PlayWrightCSharp.Driver;

public class PlaywrightDriverInitializer : IPlaywrightDriverInitializer
{
    public const float DEFAULT_TIMEOUT = 30f;
    public async Task<IBrowser> GetChromeDriver(TestSettings testSettings)
    {
        var options = GetParamaters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
        options.Channel = "chrome";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }
    public async Task<IBrowser> GetChromiumDriver(TestSettings testSettings)
    {
        var options = GetParamaters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
        options.Channel = "chromium";
        return await GetBrowserAsync(DriverType.Chromium, options);
    }
    public async Task<IBrowser> GetEdgeDriver(TestSettings testSettings)
    {
        var options = GetParamaters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
        options.Channel = "edge";
        return await GetBrowserAsync(DriverType.WebKit, options);
    }
    public async Task<IBrowser> GetFirefoxDriver(TestSettings testSettings)
    {
        var options = GetParamaters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
        options.Channel = "firefox";
        return await GetBrowserAsync(DriverType.Firefox, options);
    }
    public async Task<IBrowser> GetWebKitDriver(TestSettings testSettings)
    {
        var options = GetParamaters(testSettings.Args, testSettings.Timeout, testSettings.Headless, testSettings.SlowMo);
        options.Channel = "webkit";
        return await GetBrowserAsync(DriverType.WebKit, options);
    }

    private async Task<IBrowser> GetBrowserAsync(DriverType driverType, BrowserTypeLaunchOptions options)
    {
        var playwright = await Playwright.CreateAsync();
        return await playwright[driverType.ToString().ToLower()].LaunchAsync(options);
    }

    private BrowserTypeLaunchOptions GetParamaters(string[]? args, float? timeout = DEFAULT_TIMEOUT, bool? headless = true, float? slowmo = null)
    {
        return new BrowserTypeLaunchOptions
        {
            Args = args,
            Timeout = ToMilliseconds(timeout),
            Headless = headless,
            SlowMo = slowmo
        };
    }

    private static float? ToMilliseconds(float? seconds)
    {
        return seconds * 1000;
    }

}
