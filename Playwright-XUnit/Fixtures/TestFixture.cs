using Playwright_Automation_Framework.Config;
using Playwright_Automation_Framework.Driver;

namespace PlayWrightCSharp.Fixtures;

public interface ITestFixture
{
    Task NavigateToURL();
    Task TakeScreenShot(string filename);
}

public class TestFixture : ITestFixture
{
    private readonly IPlaywrightDriver _playwrightDriver;
    private readonly TestSettings _testSettings;
    private Task<IPage> _page;

    public TestFixture(IPlaywrightDriver playwrightDriver, TestSettings testSettings)
    {
        _playwrightDriver = playwrightDriver;
        _testSettings = testSettings;
        _page = playwrightDriver.Page;
    }

    public async Task NavigateToURL()
    {
        await (await _page).GotoAsync(_testSettings.ApplicationURL);
    }

    public async Task TakeScreenShot(string filename)
    {
        await (await _page).ScreenshotAsync(new() { Path = filename, FullPage = true });
    }
}