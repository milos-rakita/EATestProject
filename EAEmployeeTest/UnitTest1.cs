using System;
using EAAutoFramework.Base;
using EAAutoFramework.Helpers;
using EAEmployeeTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using EAAutoFramework.Config;


namespace EAEmployeeTest
{
    [TestClass]
    public class UnitTest1 : HookInitialize
    {

       


        [TestMethod]
        public void TestMethod1()
        {
            string fileName = Environment.CurrentDirectory.ToString() + "\\Data\\Testdata.xlsx";
            ExcelHelper.PopulateInCollection(fileName);

            LogHelpers.Write("Navigate to the page");
            CurrentPage = GetInstance<LogInPage>();
            CurrentPage.As<LogInPage>().CheckIfLoginExist();
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