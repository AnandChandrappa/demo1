using OpenQA.Selenium;
using System;

namespace UnitTest.PageObjects
{
    public class searchResults
    {
        IWebDriver driver;
        public searchResults(IWebDriver driver)
        {
            this.driver = driver;
        }

        
        public IWebElement firstProduct => driver.FindElement(By.XPath("//div[@class='s-result-list s-search-results sg-row']//div[@data-index='0']//h2//a"));
        

        public void clickOnFirstProduct()
        {            
            firstProduct.Click();
        }

        public string getFirstProductName()
        {
            return firstProduct.Text;
        }

        public Boolean verifyProductLandPage(string prodName)
        {
            return firstProduct.Text.ToLower().Contains(prodName.ToLower());            
        }


    }
}
