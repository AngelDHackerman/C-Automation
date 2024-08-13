using Microsoft.Playwright;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

class DemoQaTests { 
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;

    // Setup: Start Playwright and the browser before each test
    public async Task Setup() {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {Headless = false});
        _page = await _browser.NewPageAsync();
        await _page.SetViewportSizeAsync(1920, 1080);
        await _page.GotoAsync("https://demoqa.com/text-box");
    }

    // Teardown: Close the browser after each test
    public async Task Teardown() {
        await _browser.CloseAsync();
    }

    // Test: Happy Path
    public async Task TestHappyPath() {
        await Setup();

        // Fill out the form with valid values
        await _page.FillAsync("//*[@id='userName']", "Angel Hackerman");
        await _page.FillAsync("//*[@id='userEmail']", "angel@testing.com"); 
        await _page.FillAsync("//*[@id='currentAddress']", "123 Fake Street");
        await _page.FillAsync("//*[@id='permanentAddress']", "Another Fake Street");

        // Validate that values were properly added (assertions)
        
    }

}

// https://chatgpt.com/c/fc5489f4-2f06-4514-ad7f-8e664d098a64
// seguir trabajando con esa conversacion