using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        // Instalar navegadores de Playwright
        var exitCode = Microsoft.Playwright.Program.Main(new[] { "install" });
        if (exitCode != 0)
        {
            throw new Exception($"Playwright exited with code {exitCode}");
        }

        // Continuar con el resto de tu código
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,   // allow to see the browser while testing
        });

        var page = await browser.NewPageAsync();
        await page.SetViewportSizeAsync(1920, 1080);
        await page.GotoAsync("https://demoqa.com/text-box");

        // Seleccionar elementos usando XPath e interactuar con ellos
        await page.FillAsync("//*[@id='userName']", "Angel Hackerman");

        await page.WaitForTimeoutAsync(4000); // Esperar 3 segundos antes de cerrar el navegador
        await browser.CloseAsync();
    }
}
