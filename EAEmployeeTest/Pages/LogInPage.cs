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
    public class LogInPage : BasePage
    {
        [FindsBy(How = How.Name, Using = "username")]
        IWebElement txtUserName { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "tdb1")]
        IWebElement btnLogin { get; set; }

        [FindsBy(How = How.Id, Using = "")]
        IWebElement lbtCustomerPage { get; set; }

        public void LogIn(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);

        }

        public void ClikLogInBTN()
        {
            btnLogin.Click();
        }

        public CustomersPage ClickOnCustomerPage()
        {
            lbtCustomerPage.Click();
            return GetInstance<CustomersPage>();
        }

        internal void CheckIfLoginExist()
        {
            txtUserName.AssertElemnetPresent();
        }
    }
}
