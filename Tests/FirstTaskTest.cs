using AQA_Task2.Pages;
using Serilog;
using FluentAssertions;

namespace AQA_Task2.Tests;

[TestClass]
public class FirstTaskTest : BaseTest
{
    [TestMethod]
    [DataRow("edge","Java")]
    [DataRow("firefox", "Java")]
    public void SearchVacancies_ShouldFindResultsWithVacancyDetails(string browser, string keyword)
    {
        Log.Information("Starting {Keyword} vacancy search on {Browser}", keyword,browser);

        _driver = WebDriverFactory.CreateDriver(GetBrowserType(browser));
        _driver.Navigate().GoToUrl(BaseUrl);

        var mainPage = new MainPage(_driver);
        
        mainPage.ClickOnCareersLink();
        mainPage.InputKeyword(keyword);
        mainPage.ClickOnLocationField();
        mainPage.SelectAllLocations();
        mainPage.SelectRemoteOption();
        mainPage.ClickFindButton();
            
        var lastResultElement = mainPage.GetLastCareerResult();
        lastResultElement.Should().NotBeNull();

        mainPage.ClickViewAndApplyButton();
            
        var resultInLastElement = mainPage.GetCareerSpecificDetails(keyword);
        resultInLastElement.Should().NotBeNull();

        Log.Information("{Keyword} vacancy search test passed on {Browser}", keyword,browser);
    }
}