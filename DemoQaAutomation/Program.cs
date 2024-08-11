using Microsoft.Playwright;
using System;
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
}