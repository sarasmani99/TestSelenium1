using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Automation.Driver;

namespace WMS.Automation.Pages
{
    public class LogInPage:BasePage
    {
        public LogInPage(IAppDriver driver):base(driver)
        {
            
        }

        public void Navigate()
        {
            Navigate("login");
        }

        public string Email
        {
            set => FindByName("username").SendKeys(value);
        }

        public string Password
        {
            set => FindByName("password").SendKeys(value);
        }

        public void CheckRememberMe()
        {
            var chk = FindById("remember-me");
            chk.Click();
        }

        public void ClickLogIn()
        {
            var btn=FindByXPath("//*[@id=\"loginfrm\"]/div[1]/div[5]/button");
            btn.Click();
        }

        public string LogInResult
        {
            get => FindByClassName("resultlogin").Text;
        }

        public bool SummaryHasErrorMessage(string[] messages)
        {
            bool isContains = false;
            var summary = FindByClassName("resultlogin");
            foreach (var message in messages)
            {
                if (summary.Text.Contains(message))
                {
                    isContains = true;
                }
            }
            if (isContains)
                return true;
            else
                return false;
        }

    }
}
