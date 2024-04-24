using Xunit;

namespace PlayWrightCSharp.Test;

public class Class1
{
    [Fact]
    public async Task APITest()
    {
        var playwright = await Playwright.CreateAsync();
        var requestContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = "https://api.chatbot.com/"
        });

        var response = await requestContext.GetAsync("");

        var data = await response.JsonAsync();
    }
}