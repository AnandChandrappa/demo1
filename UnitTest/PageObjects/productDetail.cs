using OpenQA.Selenium;
using System;


namespace UnitTest.PageObjects
{
    public class productDetail
    {
        IWebDriver driver;
        public productDetail(IWebDriver driver)
        {
            this.driver = driver;
        }

        public String prodName;
        
        public IWebElement productName => driver.FindElement(By.CssSelector("#title"));
        public IWebElement addToCartBtn => driver.FindElement(By.CssSelector("#add-to-cart-button"));
        
        public Boolean verifyProduct(string productName)
        {
            return this.productName.Text.Contains(productName);
        }

        public void clickOnAddToCartBtn()
        {
            addToCartBtn.Click();
        }

    }
}
