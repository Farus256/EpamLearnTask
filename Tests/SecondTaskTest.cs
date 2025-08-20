using AQA_Task2.Pages;
using Serilog;
using FluentAssertions;

namespace AQA_Task2.Tests;

[TestClass]
public class SecondTaskTest:BaseTest
{
    [TestMethod]
    [DataRow("Blockchain", "edge")]
    [DataRow("Blockchain", "firefox")]
    [DataRow("Cloud", "edge")]
    [DataRow("Cloud", "firefox")]
    [DataRow("Automation", "edge")]
    [DataRow("Automation", "firefox")]
    public void SiteSearch_ShouldReturnRelevantResults(string keyword, string browser)
    {
        Log.Information("Starting global site search for {SearchTerm} on {Browser}", keyword, browser);
        
        _driver = WebDriverFactory.CreateDriver(GetBrowserType(browser));
        _driver.Navigate().GoToUrl(BaseUrl);

        var mainPage = new MainPage(_driver);

        mainPage.ClickMagnifierIcon();
        mainPage.EnterSearchTerm(keyword);
        mainPage.ClickSearchFindButton();
        
        var resultLinks = mainPage.GetSearchResultLinks();
        resultLinks.Should().NotBeEmpty();
        
        var allContainTerm = resultLinks.Any(link =>
        {
            var linkTextUpper = link.Text.ToUpperInvariant();
            return keyword.Any(word => linkTextUpper.Contains(word));
        });
        allContainTerm.Should().BeTrue();

        Log.Information("Site search test for {SearchTerm} passed on {Browser}", keyword, browser);
    }
}