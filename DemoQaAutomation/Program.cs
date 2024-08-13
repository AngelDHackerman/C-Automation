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

        string fullName = "Angel Hackerman";
        string email = "Angel@test.com";
        string currentAddress = "123 Street";
        string permanentAddress = "Main Road 130";

        await _page.FillAsync("//*[@id='userName']", fullName);
        await _page.FillAsync("//*[@id='userEmail']", email); 
        await _page.FillAsync("//*[@id='currentAddress']", currentAddress);
        await _page.FillAsync("//*[@id='permanentAddress']", permanentAddress);

        // Click on the "Submit" button
        await _page.ClickAsync("//*[@id='submit']");

        // Capture the added values (assertions)
        var nameText = await _page.TextContentAsync("#name");
        var emailText = await _page.TextContentAsync("#email");
        var currentAddressText = await _page.TextContentAsync("#currentAddress");
        var permanentAddressText = await _page.TextContentAsync("#permanentAddress");

        // Make sure that inputs and captured text match
        Console.WriteLine(nameText.Contains($"Name:{fullName}") ? "Name is correct": "Name is incorrect");
        Console.WriteLine(emailText.Contains($"Email:{email}") ? "Email is correct" : "Email is incorrect");
        Console.WriteLine(currentAddressText.Contains($"Current Address: {currentAddress}") ? "Current address is correct" : "Current address is incorrect");
        Console.WriteLine(permanentAddressText.Contains($"Permanent Address: {permanentAddress}") ? "Permanent Address is correct" : "Permanent Address is incorrect");

        // Wait 3 seconds in order to see the values on the screen
        await _page.WaitForTimeoutAsync(3000);

        await Teardown();
    }

}

class Program { 
    public static async Task Main(string[] args) {
        var test = new DemoQaTests();
        await test.TestHappyPath();
    }
}
