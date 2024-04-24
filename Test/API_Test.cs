namespace PlayWrightCSharp.Test;

public class API_Test
{
    [Fact]
    public async Task ShuffleCards()
    {
        var playwright = await Playwright.CreateAsync();

        var request = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
        {
            BaseURL = "https://deckofcardsapi.com/api/deck/",
            IgnoreHTTPSErrors = true
        });

        var response = await request.PostAsync("new/shuffle/?deck_count=1");

    }

    [Fact]
    public async Task NewDeck()
    {
        var playwright = await Playwright.CreateAsync();

        var request = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions()
        {
            BaseURL = "https://deckofcardsapi.com/api/deck/",
            IgnoreHTTPSErrors = true
        });

        var response = await request.PostAsync("", new APIRequestContextOptions()
        {
            DataObject = new
            {
                success = true,
                deck_id = "3p40paa87x90",
                shuffled = false,
                remaining = 52,
                jokers_enabled = true
            }
        });

        var jsonString = await response.JsonAsync();

    }
}
