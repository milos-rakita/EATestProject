using EAAutoFramework.Base;
using EAAutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAEmployeeTest.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How =How.LinkText,Using ="Log in")]
        IWebElement lnklogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "Employee List")]
        IWebElement lnkEmployeeList { get; set; }

        [FindsBy(How = How.LinkText, Using = "//a[@title='Manage']")]
        IWebElement lnkLoggedInUser { get; set; }

        public LogInPage ClickLogin()
        {
            lnklogin.Click();
            return GetInstance<LogInPage>();
        }

        public string GetLoggedInUser()
        {
            return lnkLoggedInUser.GetLinkText();
        }

        public void CheckIfLogInExist()
        {
            lnklogin.AssertElemnetPresent();
        }
    }
}
