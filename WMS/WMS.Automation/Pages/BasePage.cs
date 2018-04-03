using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Automation.Driver;

namespace WMS.Automation
{
    public class BasePage
    {
        protected IAppDriver Driver { get; private set; }

        public BasePage(IAppDriver driver)
        {
            Driver = driver;
        }

        public IWebElement FindById(string id)
        {
            return Driver.FindElement(By.Id(id));
        }

        public IWebElement FindByName(string name)
        {
            return Driver.FindElement(By.Name(name));
        }

        public IWebElement FindByXPath(string xpath)
        {
            return Driver.FindElement(By.XPath(xpath));
        }
       
        public IWebElement FindByClassName(string className)
        {
            WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));
            return wait.Until(driver => 
            {
                IWebElement element = driver.FindElement(By.ClassName(className));
                return element.Displayed? element:null;
            });
        }

        public void Navigate(string pageUrl)
        {
            Driver.Navigate().GoToUrl(this.Driver.AppURL + "/" + pageUrl);
        }
    }
}
