using AQA_Task2.Pages;
using Serilog;
using FluentAssertions;
using OpenQA.Selenium.Support.UI;

namespace AQA_Task2.Tests;
[TestClass]
public class ThirdTaskTest : BaseTest
{
    [TestMethod]
    [DataRow("edge")]
    [DataRow("firefox")]
    public void ValidateDownloadedFile_ShouldVerifyDownloadedFile(string browser)
    {
        Log.Information("Start Validating downloaded file");
        
        var downloadDir = Path.Combine(Directory.GetCurrentDirectory(), "Downloads");
        var expectedFile = Path.Combine(downloadDir, "EPAM_Corporate_Overview_Q4FY-2024.pdf");
        
        _driver = WebDriverFactory.CreateDriverWithDownloadOption(GetBrowserType(browser), downloadDir);
        _driver.Navigate().GoToUrl(BaseUrl);
        
        var mainPage = new MainPage(_driver);
        
        mainPage.ClickAboutButton();
        mainPage.ClickDownloadButton();
        
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        var downloadedFile = wait.Until(driver => File.Exists(expectedFile));
        
        downloadedFile.Should().BeTrue();

        if (downloadedFile)
        {
            File.Delete(expectedFile);
        }
        
        Log.Information("Finished Validating downloaded file");
    }
}