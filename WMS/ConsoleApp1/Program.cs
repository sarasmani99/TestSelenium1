using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Automation.Driver;
using WMS.Automation.Pages;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (IAppDriver driver = new AppChromeDriver())
            {
                driver.AppURL = "https://www.phptravels.net";
                LogInPage login = new LogInPage(driver);
                login.Navigate();
                login.Email= "user@phptravels.com";
                login.Password="douser";
                login.CheckRememberMe();
                login.ClickLogIn();
                Console.WriteLine(login.LogInResult);
            }
        }
    }
}
