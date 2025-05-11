using Microsoft.Playwright;
using Reqnroll;

namespace NASA.UI.Tests.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _context;
        private static IPlaywright _playwright;
        private static IBrowser _browser;
        private IPage _page;

        public Hooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeTestRun]
        public static async Task SetupBrowser()
        {
            _playwright = await Playwright.CreateAsync();
            var headlessEnv = Environment.GetEnvironmentVariable("HEADLESS");
            bool isHeadless = string.IsNullOrEmpty(headlessEnv) || headlessEnv.ToLower() != "false";
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = isHeadless
            });
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            var contextBrowser = await _browser.NewContextAsync( new BrowserNewContextOptions 
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });
            _page = await contextBrowser.NewPageAsync();
            _context["Page"] = _page;
        }

        [AfterScenario]
        public async Task AfterScenario() =>
            await _page.CloseAsync();
    }
}
