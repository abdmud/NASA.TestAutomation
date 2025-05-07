using Microsoft.Playwright;

public class SignUpPage
{
    private readonly IPage _page;
    public SignUpPage(IPage page)
    {
        _page = page;
    }

    public async Task NavigateToSignUpAsync()
    {
        await _page.GotoAsync("https://api.nasa.gov");
    }
    public async Task CompleteSignUpFormAsync(string firstName, string lastName, string email)
    {
        await _page.Locator("[id='user_first_name']").FillAsync(firstName);
        await _page.Locator("[id='user_last_name']").FillAsync(lastName);
        await _page.Locator("[id='user_email']").FillAsync(email);
    }
    public async Task ClickSubmitButtonAsync()
    {
        // Click the "Sign Up" button and wait for the page to finish loading
        await _page.Locator("button", new PageLocatorOptions { HasTextString = "Sign Up" }).ClickAsync();
        await _page.WaitForLoadStateAsync(LoadState.NetworkIdle);
    }
    public async Task<string> SignUpSuccessAsync()
    {
        // Locate and wait for the success message to be visible
        var successLocator = _page.Locator("#apidatagov_signup p").First;
        await successLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

        // Return the inner text of the success message
        return await successLocator.InnerTextAsync();
    }
    public async Task<string> GetErrorMessageByIdAsync(string fieldId)
    {
        var locator = _page.Locator($"[id='{fieldId}_feedback']");
        await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        return await locator.InnerTextAsync();
    }
    public Task<string> GetFirstNameFieldErrorMessageAsync() =>
        GetErrorMessageByIdAsync("user_first_name");

    public Task<string> GetLastNameFieldErrorMessageAsync() =>
        GetErrorMessageByIdAsync("user_last_name");

    public Task<string> GetEmailFieldErrorMessageAsync() =>
        GetErrorMessageByIdAsync("user_email");
}