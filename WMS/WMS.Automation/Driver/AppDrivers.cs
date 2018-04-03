using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS.Automation.Driver
{

    public interface IAppDriver:IWebDriver
    {
        string AppURL { get; set; }
    }

    public class AppChromeDriver : ChromeDriver, IAppDriver
    {
        public string AppURL { get; set; }
    }

    public class AppFireFoxDriver : FirefoxDriver, IAppDriver
    {
        public string AppURL { get; set; }
    }

    public class AppIEDriver : InternetExplorerDriver, IAppDriver
    {
        public string AppURL { get; set; }
    }
}
