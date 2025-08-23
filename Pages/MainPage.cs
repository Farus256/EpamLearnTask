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
    private readonly By _aboutButton = By.LinkText("About");
    private readonly By _downloadButton = By.XPath("//a[@class='button-ui-23 btn-focusable' and @download]");

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
}
