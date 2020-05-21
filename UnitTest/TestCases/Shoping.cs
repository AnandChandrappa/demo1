using System.Configuration;
using NUnit.Framework;
using AventStack.ExtentReports;
using UnitTest.PageObjects;


namespace UnitTest.TestCases
{
    [TestFixture]
    public class Shoping : BaseTest
    {
        [Test]
        public void TC_AddProductToBasket([Values("ipad","iphone")] string products)
        {
            test = extent.CreateTest("Test Case to Search "+ products);           
                
            var homePage = new home();
            var loginPage = new login(driver);
            var searchPage = new searchResults(driver);
            var productDetailPage = new productDetail(driver);
            var basketPage = new basket(driver);
            string productNameCaptured;

            //Login to Amazon
            test.Log(Status.Info, "Login to Amamzon website");
            //Assert.IsTrue(homePage.verifyHomePage("Sign in"), "Amamzon home page is unavailable");
            AllClassesObjects aco = new AllClassesObjects();
            Assert.IsTrue(aco.homePage.verifyHomePage("Sign in"), "Amamzon home page is unavailable");
            homePage.clickOnSignIn();
            loginPage.setUser_email(ConfigurationManager.AppSettings.Get("email"));
            loginPage.clickOnContinue();
            loginPage.setUser_password(ConfigurationManager.AppSettings.Get("password"));
            loginPage.clickOnSubmit();
            Assert.IsTrue(homePage.verifyHomePage(ConfigurationManager.AppSettings.Get("user")), "User is not logged in");
            test.Log(Status.Info, "Login successfull");

            //Search the product in Amazon
            homePage.setSearch_Product(products);
            homePage.clickOnSearchBtn();
            productNameCaptured = searchPage.getFirstProductName();
            searchPage.verifyProductLandPage(products);
            test.Log(Status.Info, "The first product name from search list: " + productNameCaptured);
            searchPage.clickOnFirstProduct();

            //Add product to cart
            Assert.IsTrue(productDetailPage.verifyProduct(productNameCaptured), "Failed to verify the product: " + productNameCaptured);
            productDetailPage.clickOnAddToCartBtn();
            Assert.IsTrue(basketPage.verifyProductAddedToCart(), "Failed to add product to basket");
            test.Log(Status.Info, "Successfully added product to Basket");
        }

        [Test]
        public void TC_RemoveProductFromBasket()
        {
            test = extent.CreateTest("Test Case to remove item from Basket");

            var homePage = new home(driver);
            var loginPage = new login(driver);
            var basketPage = new basket(driver);
            

            //Login to Amazon
            test.Log(Status.Info, "Login to Amamzon website");
            Assert.IsTrue(homePage.verifyHomePage("Sign in"), "Amamzon home page is unavailable");
            homePage.clickOnSignIn();
            loginPage.setUser_email(ConfigurationManager.AppSettings.Get("email"));
            loginPage.clickOnContinue();
            loginPage.setUser_password(ConfigurationManager.AppSettings.Get("password"));
            loginPage.clickOnSubmit();
            Assert.IsTrue(homePage.verifyHomePage(ConfigurationManager.AppSettings.Get("user")), "User is not logged in");
            test.Log(Status.Info, "Login successfull");

            //Remove product from Basket
            basketPage.clickOnBasket();
            Assert.IsTrue(basketPage.verifyBasketPage(), "Unable to navigate to Basket page");
            test.Log(Status.Info, "Navigated to Shopping Basket");
            basketPage.removeProductsFromBasket();
            test.Log(Status.Info, "All products removed from Basket");

        }

        [Test]
        public void TC2()
        {
            test = extent.CreateTest("Test Case2");
            test.Log(Status.Info, "this is with status.info");
            test.Log(Status.Warning, "this is with Status.Warning");
        }

        [Test]
        public void TC3()
        {
        }

    }
}
