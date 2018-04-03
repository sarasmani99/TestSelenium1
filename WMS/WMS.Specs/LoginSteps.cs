using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using WMS.Automation.Driver;
using WMS.Automation.Pages;

namespace WMS.Specs
{
    [Binding]
    public class LoginSteps : IDisposable
    {
        LogInPage loginPage = null;
        IAppDriver driver = null;
        public LoginSteps()
        {
            driver = DriverProvider.CreateDriver();
            loginPage = new LogInPage(driver);
        }

        [Given(@"I have navigated to Login page")]
        public void GivenIHaveNavigatedToLoginPage()
        {
            loginPage.Navigate();
        }
        
        [Given(@"I have entered username as (.*)")]
        public void GivenIHaveEnteredUsernameAs(string userName)
        {
            loginPage.Email = userName;
        }
        
        [Given(@"I have entered password as (.*)")]
        public void GivenIHaveEnteredPasswordAs(string password)
        {
            loginPage.Password = password;
        }
        
        [When(@"I have pressed Login button")]
        public void WhenIHavePressedLoginButton()
        {
            loginPage.ClickLogIn();
        }
        
        [Then(@"I should see MyAccountPage")]
        public void ThenIShouldSeeMyAccountPage()
        {

        }

        [Then(@"I should see error login failed message")]
        public void ThenIShouldSeeErrorLoginFailedMessage()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Invalid Email or Password", loginPage.LogInResult);
        }


        public void Dispose()
        {
            driver.Dispose();
        }
    }
}
