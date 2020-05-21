using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace UnitTest.PageObjects
{
    public class basket
    {
        IWebDriver driver;
        public basket(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement navCartLink => driver.FindElement(By.CssSelector("#nav-cart"));

        
        public IWebElement basketHeader => driver.FindElement(By.XPath("//h1"));

        public IList<IWebElement> basketItems => driver.FindElements(By.XPath("//div[@data-giftable='1']"));

        public IWebElement proceedToCheckoutBtn => driver.FindElement(By.CssSelector("#hlb-ptc-btn-native")); 

        public void clickOnBasket()
        {
            navCartLink.Click();            
        }

        public Boolean verifyProductAddedToCart()
        {            
            if (proceedToCheckoutBtn.Displayed)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void removeProductsFromBasket()
        {
            int basketItems_count = basketItems.Count;
            while (basketItems_count > 0)
            {
                driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
                System.Threading.Thread.Sleep(2000);
                basketItems_count--;
            }            

        }

        public Boolean verifyBasketPage()
        {
            if (driver.PageSource.Contains("Shopping Basket"))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
