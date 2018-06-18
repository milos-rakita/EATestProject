using System;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : Base
    {

        string url = "http://www.gcreddy.com/project1/admin/login.php";
       // private IWebDriver _driver;
       public void OpenBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.IE:
                    //DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    //DriverContext.Driver = new ChromeDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            //DriverContext.Driver = new FirefoxDriver();
            //DriverContext.Driver.Navigate().GoToUrl(url);

            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Testdata.xlsx";
            ExcelHelper.PopulateInCollection(fileName);

            LogHelpers.Write("Createlog file");

            OpenBrowser(BrowserType.Firefox);
            LogHelpers.Write("Openthe browser");

            DriverContext.Browser.GoToUrl(url);
            LogHelpers.Write("Navigate to the page");

            CurrentPage = GetInstance<LogInPage>();
            CurrentPage.As<LogInPage>().LogIn(ExcelHelper.ReadData(1,"Username"), ExcelHelper.ReadData(1, "Password"));
            CurrentPage.As<LogInPage>().ClikLogInBTN();

            //CurrentPage = CurrentPage.As<LogInPage>().CustomersMenu();
            //CurrentPage.As<CustomersPage>.ClickCustomerMenu();
        }

        public void Login()
        {
            LogInPage page = new LogInPage( );
            page.LogIn("admin", "Temp@2018");
            page.ClikLogInBTN();
        }

        public void ClickCustomerMenu()
        {
            //cu
        }
    }
}