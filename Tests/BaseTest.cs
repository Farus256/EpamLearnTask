using OpenQA.Selenium;
using Serilog;

namespace AQA_Task2.Tests;

public class BaseTest
{
    protected IWebDriver _driver;
    protected const string BaseUrl = "https://www.epam.com/";
    
    public const int ShortWait = 2;
    public const int MediumWait = 5;
    public const int LongWait = 10;
    
    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void SetUp()
    {
        var logDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        Directory.CreateDirectory(logDir);
        var logFile = Path.Combine(logDir, "testlog-.txt");
        Log.Logger = new LoggerConfiguration()
            .WriteTo.File(logFile)
            .CreateLogger();
        
        Log.Information("Test started");
    }

    [TestCleanup]
    public void EndTest()
    {
        try
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed && _driver != null)
            {
                Log.Information("Test failed");
                Log.Error("Test {TestName} failed with outcome {Outcome}",
                    TestContext.TestName, TestContext.CurrentTestOutcome);
            }
            else
            {
                Log.Information("Test {TestName} completed successful", TestContext.TestName);
            }
        }
        finally
        {
            try
            {
                _driver?.Quit();
                _driver?.Dispose();
                _driver = null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error closing driver");
            }
            Log.Information("Test ended");
            Log.CloseAndFlush();
        }
    }

    protected BrowserType GetBrowserType(string browser)
    {
        if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
            return BrowserType.Firefox;
        if (browser.Equals("edge", StringComparison.OrdinalIgnoreCase))
            return BrowserType.Edge;
        throw new ArgumentException("Unsupported browser type");
    }
}
