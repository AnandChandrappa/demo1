using OpenQA.Selenium;

namespace UnitTest.PageObjects
{
    public class login
    {
        IWebDriver driver;

        public login(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserMailTxt => driver.FindElement(By.CssSelector("#ap_email"));
        
        public IWebElement ContinueBtn => driver.FindElement(By.CssSelector("#continue"));

        public IWebElement PwdTxt => driver.FindElement(By.CssSelector("#ap_password"));

        public IWebElement SubmitBtn => driver.FindElement(By.CssSelector("#signInSubmit"));

        public void setUser_email(string email)
        {
            UserMailTxt.Clear();
            UserMailTxt.SendKeys(email);
        }

        public void setUser_password(string password)
        {
            PwdTxt.Clear();
            PwdTxt.SendKeys(password);
        }

        public void clickOnContinue()
        {
            ContinueBtn.Click();
        }

        public void clickOnSubmit()
        {
            SubmitBtn.Click();
        }
    }
}
