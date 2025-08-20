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
}