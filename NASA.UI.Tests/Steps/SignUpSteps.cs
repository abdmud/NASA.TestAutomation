using Reqnroll;
using Microsoft.Playwright;

[Binding]
public class SignUpSteps
{
    private readonly ScenarioContext _context;
    private IPage _page;
    private SignUpPage _signupPage;

    public SignUpSteps(ScenarioContext context)
    {
        _context = context;
        _page = (IPage)_context["Page"];
        _signupPage = new SignUpPage(_page);
    }

    private const string FirstName = "first";
    private const string LastName = "last";
    private const string Email = "first@last.com";

    [Given("I navigate to the sign up page")]
    public async Task GivenINavigateToTheSignUpPage() =>
        await _signupPage.NavigateToSignUpAsync();

    [When("I fill in the sign up form with valid data")]
    public async Task WhenIFillInTheSignUpFormWithValidData()
    {
        var email = "first@last.com";
        _context["Email"] = email;

        await _signupPage.CompleteSignUpFormAsync(FirstName, LastName, Email);
    }

    [When("I click the submit button")]
    public async Task WhenIClickTheSubmitButton()
    {
        await _signupPage.ClickSubmitButtonAsync();
    }

    [Then("I should see a success message")]
    public async Task ThenIShouldSeeASuccessMessage()
    {
        var successMessage = await _signupPage.SignUpSuccessAsync();
        var expectedMessage = $"Your API key for {Email} has been e-mailed to you. You can use your API key to begin making web service requests immediately.";
        Assert.That(successMessage, Is.EqualTo(expectedMessage));
    }

    [Then("I should see a validation error message for the required fields")]
    public async Task ThenIShouldSeeAValidationErrorMessageForTheRequiredFields()
    {
        var expectedNameError = "Fill out this field.";
        var expectedEmailError = "Enter an email address.";

        AssertValidationError(await _signupPage.GetFirstNameFieldErrorMessageAsync(), expectedNameError, "First Name");
        AssertValidationError(await _signupPage.GetLastNameFieldErrorMessageAsync(), expectedNameError, "Last Name");
        AssertValidationError(await _signupPage.GetEmailFieldErrorMessageAsync(), expectedEmailError, "Email");
    }

    private void AssertValidationError(string actual, string expected, string fieldName)
    {
        Assert.That(actual, Is.EqualTo(expected),
            $"Expected validation message for {fieldName} to be '{expected}', but got '{actual}'.");
    }
}