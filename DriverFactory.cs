using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace AQA_Task2;

public enum BrowserType
{
    Firefox,
    Edge
}

public class WebDriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browser)
    {
        IWebDriver driver;
        switch (browser)
        {
            case BrowserType.Firefox:
                var firefoxOptions = new FirefoxOptions();
                //firefoxOptions.AddArgument("--headless");
                driver = new FirefoxDriver(firefoxOptions);
                break;
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptions();
                //edgeOptions.AddArgument("--headless");
                driver = new EdgeDriver(edgeOptions);
                break;
            default:
                throw new ArgumentException("Unsupported browser type");
        }
        
        driver.Manage().Window.Maximize();
        return driver;
    }

    public static IWebDriver CreateDriverWithDownloadOption(BrowserType browser, string downloadDirectory)
    {
        IWebDriver driver;
        switch (browser)
        {
            case BrowserType.Firefox:
                var firefoxOptions = new FirefoxOptions();
                //firefoxOptions.AddArgument("--headless");
                firefoxOptions.SetPreference("browser.download.folderList", 2); // 2 = custom folder
                firefoxOptions.SetPreference("browser.download.dir", downloadDirectory);
                firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/pdf");
                firefoxOptions.SetPreference("pdfjs.disabled", true);
                driver = new FirefoxDriver(firefoxOptions);
                break;
            case BrowserType.Edge:
                var edgeOptions = new EdgeOptions();
                //edgeOptions.AddArgument("--headless");
                edgeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                edgeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                edgeOptions.AddUserProfilePreference("plugins.always_open_pdf_externally", true);
                driver = new EdgeDriver(edgeOptions);
                break;
            default:
                throw new ArgumentException("Unsupported browser type");
        }
        
        driver.Manage().Window.Maximize();
        return driver;
    }
}