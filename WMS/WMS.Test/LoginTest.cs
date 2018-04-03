using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;
using WMS.Automation.Driver;
using WMS.Automation.Pages;
using WMS.Test.TestData;


namespace WMS.Test
{
    [TestClass]
    public class LoginTest
    {
        const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source =.\Test\LogInData.xlsx; Extended Properties = 'Excel 12.0;HDR=yes';";
        private static IAppDriver driver;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void Init(TestContext c)
        {
            driver = CreateDriver();
        }
        public static IAppDriver CreateDriver()
        {
            string browser = System.Environment.GetEnvironmentVariable("_browser");
            Debug.WriteLine("Browser is:"+browser);
            IAppDriver driver = null;
            if(browser== "InternetExplorer")
            {
                driver = new AppIEDriver();
            }
            else
            {
                driver = new AppChromeDriver();
            }
            driver.AppURL = "https://www.phptravels.net";
            return driver;
        }
        [TestMethod]
        [DataSource("System.Data.OleDB", ConnectionString, "Sheet1$", DataAccessMethod.Sequential)]
        public void PerformLogIn()
        {
            LogInTestData data = new LogInTestData(TestContext.DataRow);
            LogInPage LogIn = new LogInPage(driver);
            LogIn.Navigate();
            LogIn.Email = data.Email;
            LogIn.Password = data.Password;
            LogIn.CheckRememberMe();
            LogIn.ClickLogIn();
            if(data.ExpectedResult=="Success")
            {
                Assert.IsTrue(true);
            }
            else if (data.ExpectedResult == "FailSummary")
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                Assert.IsTrue(LogIn.SummaryHasErrorMessage(data.ExpectedErrorMessages));
            }
            else
            {
                throw new Exception("Unknown expected result, fix data file");
            }
        }
        [ClassCleanup]
        public static void Dispose()
        {
            if(driver!=null)
            {
                driver.Quit();
            }
        }
    }
}
