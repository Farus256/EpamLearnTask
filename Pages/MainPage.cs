using System.Collections.ObjectModel;
using AQA_Task2.Tests;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace AQA_Task2.Pages;

public class MainPage : BasePage
{
    public MainPage(IWebDriver driver) : base(driver) { }

    private readonly By _careersLink = By.CssSelector("a.top-navigation__item-link[href='/careers']");
    private readonly By _keywordInput = By.Id("new_form_job_search-keyword");
    private readonly By _locationField = By.XPath("//span[@class='select2-selection__rendered']");
    private readonly By _allLocationsOption = By.XPath("//li[contains(@id,'all_locations')]");
    private readonly By _remoteOption = By.XPath("//input[@name='remote']/parent::p");
    private readonly By _findButton = By.XPath("//form[@id='jobSearchFilterForm']/button[@type='submit']");
    private readonly By _magnifierIcon = By.XPath("//button[contains(@class,'header-search__button')]");
    private readonly By _searchInput = By.Id("new_form_search");
    private readonly By _searchFindButton = By.XPath("//span[@class='bth-text-layer']/parent::button");
    private readonly By _searchResultLinks = By.XPath("//div[@class='search-results__items']//a[@class='search-results__title-link']");
    
    //Task3
    private readonly By _aboutButton = By.LinkText("About");
    private readonly By _downloadButton = By.XPath("//a[@class='button-ui-23 btn-focusable' and @download]");
    //Task4
    private readonly By _insightsButton = By.LinkText("Insights");
    private readonly By _carouselNextButton = By.XPath("//div[contains(@class,'media-content')]//button[contains(@class, 'slider__right-arrow')]");
    private readonly By _readMoreActiveCarouselLink = By.XPath("//div[@aria-hidden='false']//a[contains(@class,'link-with-bottom-arrow')]");

    public void ClickOnCareersLink() => Click(_careersLink);

    public void InputKeyword(string keyword) => Type(_keywordInput, keyword);

    public void ClickOnLocationField() => Click(_locationField);

    public void SelectAllLocations() => Click(_allLocationsOption);

    public void SelectRemoteOption() => Click(_remoteOption);

    public void ClickFindButton() => Click(_findButton);

    public void ClickMagnifierIcon() => Click(_magnifierIcon);

    public void EnterSearchTerm(string term) => Type(_searchInput, term);

    public void ClickSearchFindButton() => Click(_searchFindButton);
    
    public void ClickAboutButton() => Click(_aboutButton);
    
    public void ClickDownloadButton() => Click(_downloadButton);
    
    public void ClickReadMoreActiveCarouselLink() => Click(_readMoreActiveCarouselLink);
    
    public void ClickInsightsButton() => Click(_insightsButton);
    
    public void ClickCarouselNextButton() => Click(_carouselNextButton);

    public ReadOnlyCollection<IWebElement> GetSearchResultLinks()
    {
        return WaitForElements(_searchResultLinks, BaseTest.LongWait);
    }
    
    public IWebElement GetCareerSpecificDetails(string careerName)
    {
        return WaitForElement(By.XPath($"//p[contains(., '{careerName}')]"), BaseTest.ShortWait);
    }

    public IWebElement GetLastCareerResult()
    {
        return WaitForElement(By.XPath("//ul[contains(@class,'search-result__list')]/li[last()]"), BaseTest.LongWait);
    }
    
    public void ClickViewAndApplyButton()
    {
        Click(By.XPath("//ul[contains(@class,'search-result__list')]/li[last()]//a[text()='View and apply']"));
    }

    public string SelectTextFromCarousel()
    {
        var element = WaitForElement(
            By.XPath("//div[contains(@class,'owl-item') and contains(@class,'active')]//span[contains(@class,'museo-sans-light')]"), 
            BaseTest.LongWait);
        
        var text = element.Text;
        return text;
    }

    public IWebElement FindArticleByText(string text)
    {
        return WaitForElement(By.XPath($"//span[@class ='museo-sans-light' and contains(normalize-space(.),'{text}')]"));
    }
}
