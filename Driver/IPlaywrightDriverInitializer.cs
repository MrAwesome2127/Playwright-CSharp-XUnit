using PlayWrightCSharp.Config;

namespace PlayWrightCSharp.Driver;

public interface IPlaywrightDriverInitializer
{
    Task<IBrowser> GetChromeDriver(TestSettings testSettings);
    Task<IBrowser> GetChromiumDriver(TestSettings testSettings);
    Task<IBrowser> GetEdgeDriver(TestSettings testSettings);
    Task<IBrowser> GetFirefoxDriver(TestSettings testSettings);
    Task<IBrowser> GetWebKitDriver(TestSettings testSettings);
}