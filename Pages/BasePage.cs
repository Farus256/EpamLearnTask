using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using AQA_Task2.Tests;

namespace AQA_Task2.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver _driver;

    protected BasePage(IWebDriver driver)
    {
        _driver = driver;
    }
    
    protected IWebElement WaitForElement(By locator, int timeoutSeconds = BaseTest.MediumWait)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
        return wait.Until(driver => driver.FindElement(locator));
    }
    
    protected ReadOnlyCollection<IWebElement> WaitForElements(By locator, int timeoutSeconds = BaseTest.MediumWait)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
        return wait.Until(driver =>
        {
            var elements = driver.FindElements(locator);
            return elements.Count > 0 ? elements : null;
        });
    }
    
    protected void ScrollIntoView(IWebElement element)
    {
        ((IJavaScriptExecutor)_driver)
            .ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'});", element);
    }
    
    protected void Click(By locator, int timeoutSeconds = BaseTest.MediumWait)
    {
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
        var element = wait.Until(driver => driver.FindElement(locator));
        ScrollIntoView(element);
        element.Click();
    }
    
    protected void Type(By locator, string text, int timeoutSeconds = BaseTest.MediumWait)
    {
        var input = WaitForElement(locator, timeoutSeconds);
        ScrollIntoView(input);
        input.Clear();
        input.SendKeys(text);
    }
}