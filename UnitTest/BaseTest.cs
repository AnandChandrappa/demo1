using System.Reflection;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;

namespace UnitTest
{
    public class BaseTest
    {
        public static IWebDriver driver;
        ExtentHtmlReporter htmlReporter;
        public ExtentReports extent;
        public ExtentTest test;
        public string projPath;


        [OneTimeSetUp]
        public void globalSetup()
        {
            
            projPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            projPath = projPath.Substring(0, projPath.LastIndexOf("bin"));            
            htmlReporter = new ExtentHtmlReporter(projPath+ "Reports\\dashboard.html");
            htmlReporter.Config.DocumentTitle = "Amazon Test Execution Report";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Browser", "Chrome");
        }
        [OneTimeTearDown]
        public void globalTeardown()
        {
            extent.Flush();
            
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(projPath);
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.amazon.co.uk/";
        }

        [TearDown]
        public void Teardown()
        {
            
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>"+ TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            string tcName = TestContext.CurrentContext.Test.Name;
            //string tcName = DateTime.Now.ToString("ddHHmmssffff");

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(Status.Fail, status + errorMessage);
                test.AddScreenCaptureFromPath(CaptureScreenshot(driver, tcName));
            }

            driver.Quit();
        }

        public string CaptureScreenshot(IWebDriver driver, string screenshotName)
        {
            string fileName = projPath + "Reports\\Screenshots\\" + screenshotName + ".png";
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot screenshot = its.GetScreenshot();
            screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
            return "Screenshots\\"+screenshotName+ ".png";
        }
    }
}
