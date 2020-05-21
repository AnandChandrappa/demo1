using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace UnitTest.PageObjects
{
    public class home
    {
        IWebDriver driver;
        public home(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Search button in the home page
        public IWebElement welcomeMessage => driver.FindElement(By.XPath("//span[contains(text(),'Hello')]"));

        [FindsBy(How = How.CssSelector, Using = ".fusion-main-menu a[href*='about']")]
        private IWebElement about;
      

        [FindsBy(How = How.XPath,Using ="")]


        public IWebElement searchTextbox => driver.FindElement(By.Name("field-keywords"));

        public IWebElement signInLink => driver.FindElement(By.CssSelector("#nav-link-accountList"));

        public IWebElement searchBtn => driver.FindElement(By.XPath("//div[@class='nav-search-submit nav-sprite']//input[@class='nav-input']"));

        
        public void searchProduct(string productName)
        {
            searchTextbox.SendKeys(productName);
            searchBtn.Click();
        }

        public void clickOnSignIn()
        {
            signInLink.Click();
        }

        public void setSearch_Product(string product)
        {
            searchTextbox.Clear();
            searchTextbox.SendKeys(product);
        }

        public void clickOnSearchBtn()
        {
            searchBtn.Click();
        }

        public Boolean verifyHomePage(string userName)
        {
            return welcomeMessage.Text.ToLower().Contains(userName.ToLower());
        }
    }
}
