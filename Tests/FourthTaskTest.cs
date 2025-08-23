using AQA_Task2.Pages;
using FluentAssertions;
using Serilog;

namespace AQA_Task2.Tests;
[TestClass]
public class FourthTaskTest : BaseTest
{
    [TestMethod]
    [DataRow("edge")]
    [DataRow("firefox")]
    public void ValidateCarouselArticleName_ShouldBeSameArticle(string browser)
    {
        Log.Information("Starting carousel article name");
        
        _driver = WebDriverFactory.CreateDriver(GetBrowserType(browser));
        _driver.Navigate().GoToUrl(BaseUrl);
        
        var mainPage = new MainPage(_driver);
        mainPage.ClickInsightsButton();
        mainPage.ClickCarouselNextButton();
        mainPage.ClickCarouselNextButton();
        
        var text = mainPage.SelectTextFromCarousel();
        
        mainPage.ClickReadMoreActiveCarouselLink();
        
        mainPage.FindArticleByText(text).Should().NotBeNull();
    }
}