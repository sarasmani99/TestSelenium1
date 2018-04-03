using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Automation.Driver;

namespace WMS.Specs
{
    public static class DriverProvider
    {
        public static IAppDriver CreateDriver()
        {
            string browser = System.Environment.GetEnvironmentVariable("_browser");

            Debug.WriteLine("Browser is:" + browser);
            IAppDriver driver = null;
            if (browser == "firefox")
            {
                driver = new AppFireFoxDriver();
            }
            else if(browser == "InternetExplorer")
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
    }
}
